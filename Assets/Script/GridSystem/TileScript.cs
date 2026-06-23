using UnityEngine;
using UnityEngine.UI;

public class TileScript : MonoBehaviour
{
    public int Row;
    public int Col;
    public Image TileHexColorImage;
    public Text TileHexText;

    public bool IsOccupied;

    public int NumberValue;

    public void OnPlacedPiece(int number, Color color)
    {
        NumberValue = number;
        IsOccupied = true;

        TileHexColorImage.color = color;
        TileHexText.text = number.ToString();
    }
    public Vector3 WorldPosition
    {
        get { return transform.position; }
    }

}