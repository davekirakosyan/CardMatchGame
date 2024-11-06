using System.Collections;
using UnityEngine;

public class GameMechanics : MonoBehaviour
{
    public static GameMechanics Instance { get; private set; }

    public float flipDelay = 0.5f;

    private Card firstSelectedCard = null;
    private Card secondSelectedCard = null;
    private bool isCheckingMatch = false;
    private int pairsMatched = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OnCardSelected(Card selectedCard)
    {
        //check selected card, if it is second card call compare method
        if (isCheckingMatch || selectedCard.IsFlipped || selectedCard == firstSelectedCard)
        {
            return;
        }

        StartCoroutine(selectedCard.FlipCard(true,flipDelay));

        if (firstSelectedCard == null)
        {
            firstSelectedCard = selectedCard;
        }
        else
        {
            secondSelectedCard = selectedCard;
            CheckForMatch();
        }
    }

    private void CheckForMatch()
    {
        // compare two cards and if they are matching add score and destroy cards, if not reset their states 
        //yield return new WaitForSeconds(flipDelay);

        isCheckingMatch = true;

        if (firstSelectedCard.CardID == secondSelectedCard.CardID)
        {
            pairsMatched++;
            GameManager.Instance.AddScore(10);
            GameManager.Instance.audioManager.PlayMatchedAudio();
            StartCoroutine(firstSelectedCard.SetMatched());
            StartCoroutine(secondSelectedCard.SetMatched());

            if (pairsMatched >= (GameManager.Instance.defaultRows * GameManager.Instance.defaultColumns) / 2)
            {
                GameManager.Instance.GameOver();
            }
        }
        else
        {
            GameManager.Instance.AddScore(-2);
            GameManager.Instance.audioManager.PlayRejectedAudio();
            //yield return new WaitForSeconds(flipDelay);
            StartCoroutine(firstSelectedCard.FlipCard(false,flipDelay));
            StartCoroutine(secondSelectedCard.FlipCard(false,flipDelay));
        }

        firstSelectedCard = null;
        secondSelectedCard = null;
        isCheckingMatch = false;

    }

    public void ResetGame()
    {
        pairsMatched = 0;
        firstSelectedCard = null;
        secondSelectedCard = null;
        isCheckingMatch = false;
    }
}