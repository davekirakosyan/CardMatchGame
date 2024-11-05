using System.Collections.Generic;
using UnityEngine;

public class LayoutManager : MonoBehaviour
{
    public Transform boardTransform;        // Parent transform for all card objects
    public GameObject cardPrefab;           // Prefab for an individual card
    public float spacingHorizontal = 1f;    // Horuzontal spacing multiplier for card positioning
    public float spacingVertical = 1f;      // Vertical spacing multiplier for card positioning

    private int rows;                       // Number of rows in the grid
    private int columns;                    // Number of columns in the grid
    private List<GameObject> cards = new List<GameObject>();  // List to track created cards

    public void SetupBoard(int rows, int columns)
    {
        // Sets up the board with a specified number of rows and columns.
        this.rows = rows;
        this.columns = columns;

        ClearBoard();

        Vector2 startPos = CalculateStartPosition();

        int totalCards = rows * columns;
        for (int i = 0; i < totalCards; i++)
        {
            GameObject card = Instantiate(cardPrefab,boardTransform);

            card.GetComponent<Card>().Initialize(i / 2);

            PositionCard(card, i, startPos);

            cards.Add(card);
        }
    }

    
    private Vector2 CalculateStartPosition()
    {
        // Calculates the starting position for the grid so it is centered.
        float gridWidth = (columns - 1) * spacingHorizontal;
        float gridHeight = (rows - 1) * spacingVertical;
        return new Vector2(-gridWidth / 2, -gridHeight / 2);
    }

    
    private void PositionCard(GameObject card, int index, Vector2 startPos)
    {
        // Positions a card in the grid based on its index.
        int row = index / columns;
        int column = index % columns;

        Vector2 cardPosition = startPos + new Vector2(column * spacingHorizontal, row * spacingVertical);
        card.transform.localPosition = cardPosition;
    }

    private void ClearBoard()
    {
        foreach (GameObject card in cards)
        {
            Destroy(card);
        }
        cards.Clear();
    }
}