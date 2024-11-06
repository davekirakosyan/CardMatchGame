using UnityEngine;

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

    public void FlipCard()
    {
        IsFlipped = !IsFlipped;
        transform.Rotate(0, 180, 0);
    }

    public void SetMatched()
    {
        isMatched = true;
        Destroy(this.gameObject);
    }
}