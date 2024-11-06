using System.Collections;
using UnityEngine;

public class GameMechanics : MonoBehaviour
{
    public static GameMechanics Instance { get; private set; }

    public float flipDelay = 1.0f;

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

        selectedCard.FlipCard();

        if (firstSelectedCard == null)
        {
            firstSelectedCard = selectedCard;
        }
        else
        {
            secondSelectedCard = selectedCard;
            StartCoroutine(CheckForMatch());
        }
    }

    private IEnumerator CheckForMatch()
    {
        // compare two cards and if they are matching add score and destroy cards, if not reset their states 
        //yield return new WaitForSeconds(flipDelay);

        isCheckingMatch = true;

        if (firstSelectedCard.CardID == secondSelectedCard.CardID)
        {
            pairsMatched++;
            GameManager.Instance.AddScore(10);

            firstSelectedCard.SetMatched();
            secondSelectedCard.SetMatched();

            if (pairsMatched >= (GameManager.Instance.defaultRows * GameManager.Instance.defaultColumns) / 2)
            {
                GameManager.Instance.GameOver();
            }
        }
        else
        {
            yield return new WaitForSeconds(flipDelay);
            firstSelectedCard.FlipCard();
            secondSelectedCard.FlipCard();
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