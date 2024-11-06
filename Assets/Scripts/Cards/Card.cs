using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour
{
    public int CardID { get; private set; }
    public bool IsFlipped { get; private set; } = false;
    private bool isMatched = false;

    private void Start()
    {
        
    }

    public void OnMouseDown()
    {
        Debug.Log("Clicked" + CardID);
        if (!isMatched && !IsFlipped)
        {
            GameMechanics.Instance.OnCardSelected(this);
        }
    }

    public void Initialize(int id)
    {
        CardID = id;
    }

    public IEnumerator FlipCard(bool faceup,float delay)
    {
        
        if (!faceup)
        {
            yield return new WaitForSeconds(delay);
        }
        IsFlipped = !IsFlipped;
        GetComponent<Animator>().SetBool("Flip",IsFlipped);
        //transform.Rotate(0, 180, 0);
    }

    public IEnumerator SetMatched()
    {
        yield return new WaitForSeconds(0.2f);
        isMatched = true;
        GetComponent<Animator>().SetBool("Destroyed", true);
        //Destroy(this.gameObject);
    }
}