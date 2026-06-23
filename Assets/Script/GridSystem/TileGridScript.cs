using System.Collections.Generic;
using UnityEngine;

public class TileGridScript : MonoBehaviour
{
    public static List<TileScript> AllTiles = new List<TileScript>();
    
    [Header("References")]
    [SerializeField] private int rows = 5;
    [SerializeField] private int columns = 5;
    [SerializeField] private RectTransform container;
    [SerializeField] private GameObject hexTilePrefab;
    [SerializeField] private Vector2 spacing = new Vector2(-8f, -5f);

    private void Start()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        AllTiles.Clear();
        
        // Clear old tiles
        foreach (Transform child in container)
        {
            Destroy(child.gameObject);
        }

        float totalWidth = container.rect.width;
        float totalHeight = container.rect.height;

        float cellWidth = (totalWidth - (columns - 1) * spacing.x) / columns;
        float cellHeight = (totalHeight - (rows - 1) * spacing.y) / rows;

        float cellSize = Mathf.Min(cellWidth, cellHeight);

        // Hex tile size
        Vector2 tileSize = new Vector2(cellSize, cellSize);

        float gridWidth = columns * tileSize.x + (columns - 1) * spacing.x;

        Vector2 gridOrigin = new Vector2(-gridWidth * 0.5f, totalHeight * 0.5f);

        for (int row = 0; row < rows; row++)
        {
            bool oddRow = row % 2 == 1;

            int currentColumns = oddRow ? columns - 1 : columns;

            float rowOffset = oddRow ? (tileSize.x + spacing.x) * 0.5f : 0f;

            for (int col = 0; col < currentColumns; col++)
            {
                GameObject tile = Instantiate(hexTilePrefab, container, false);

                TileScript tileScript = tile.GetComponent<TileScript>();

                tileScript.Row = row;
                tileScript.Col = col;
             
                AllTiles.Add(tileScript);

                RectTransform rect = tile.GetComponent<RectTransform>();

                rect.anchorMin = rect.anchorMax = rect.pivot = new Vector2(0.5f, 0.5f);

                rect.sizeDelta = tileSize;

                // Hex position
                Vector2 position = new Vector2(gridOrigin.x + rowOffset + col * (tileSize.x + spacing.x) +
                    tileSize.x * 0.5f, gridOrigin.y - row * (tileSize.y * 0.82f) - tileSize.y * 0.5f);

                rect.anchoredPosition = position;

                tile.name = $"HexTile_{row}_{col}";
            }
        }
    }

 
}