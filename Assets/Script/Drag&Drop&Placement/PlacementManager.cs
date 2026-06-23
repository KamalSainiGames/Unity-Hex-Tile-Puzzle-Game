using System.Collections.Generic;
using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    public static PlacementManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public TileScript GetNearestTile(Vector3 position)
    {
        TileScript nearestTile = null;

        float minDistance = float.MaxValue;

        foreach (TileScript tile in TileGridScript.AllTiles)
        {
            float distance =Vector3.Distance(position, tile.transform.position);

            if (distance < minDistance)
            {
                minDistance = distance;
                nearestTile = tile;
            }
        }

        return nearestTile;
    }
    public TileScript GetNeighbourTile(TileScript centerTile, int rotationIndex)
    {
        int row = centerTile.Row;
        int col = centerTile.Col;

        bool oddRow = row % 2 == 1;

        int[,] evenOffsets =
        {
            {-1,0},
            {-1,-1},
            {0,-1},
            {1,-1},
            {1,0},
            {0,1}
        };

        int[,] oddOffsets =
        {
            {-1,1},
            {-1,0},
            {0,-1},
            {1,0},
            {1,1},
            {0,1}
        };

        int targetRow;
        int targetCol;

        if (oddRow)
        {
            targetRow = row + oddOffsets[rotationIndex, 0];
            targetCol = col + oddOffsets[rotationIndex, 1];
        }
        else
        {
            targetRow = row + evenOffsets[rotationIndex, 0];
            targetCol = col + evenOffsets[rotationIndex, 1];
        }

        foreach (TileScript tile in TileGridScript.AllTiles)
        {
            if (tile.Row == targetRow &&
               tile.Col == targetCol)
            {
                return tile;
            }
        }

        return null;
    }
    public bool IsValidPlacement(TileScript tileA, TileScript tileB)
    {
        if (tileA == null)
            return false;

        if (tileB == null)
            return false;

        if (tileA.IsOccupied)
            return false;

        if (tileB.IsOccupied)
            return false;

        return true;
    }

    public void PlacePiece(TileScript tileA, TileScript tileB, GameObject piece)
    {
        PieceData data =piece.GetComponent<PieceData>();

        tileA.OnPlacedPiece(data.firstNumber,data.hexa);

        tileB.OnPlacedPiece(data.secondNumber,data.hexb);

        Destroy(piece);

        PieceGenerator.Instance.GeneratePiece();
    }
}