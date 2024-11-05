using System.Collections.Generic;
using UnityEngine;

public class LayoutManager : MonoBehaviour
{
    public Transform boardTransform;        // Parent transform for all card objects
    public GameObject cardPrefab;           // Prefab for an individual card
    public float spacing = 1.1f;            // Spacing multiplier for card positioning

    private int rows;                       // Number of rows in the grid
    private int columns;                    // Number of columns in the grid
    private List<GameObject> cards = new List<GameObject>();  // List to track created cards

    public void SetupBoard(int rows, int columns)
    {
        // Sets up the board with a specified number of rows and columns.
    }

    
    private Vector2 CalculateStartPosition()
    {
        // Calculates the starting position for the grid so it is centered.
    }

    
    private void PositionCard(GameObject card, int index, Vector2 startPos)
    {
        // Positions a card in the grid based on its index.
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