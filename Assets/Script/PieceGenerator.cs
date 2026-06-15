using UnityEngine;
using UnityEngine.UI;

public class PieceGenerator : MonoBehaviour
{ 
   
    [SerializeField] private Transform spawnPoint;

    public GameObject currentPiece;

    private void Start()
    {
        GeneratePiece();
    }

    public void GeneratePiece()
    {   

        PieceRotation pieceRotation = currentPiece.GetComponent<PieceRotation>();
        pieceRotation.RotatePiece();

        PieceData pieceData = currentPiece.transform.GetChild(0).GetComponent<PieceData>();

        int num1 = NumberPoolManager.Instance.GetRandomNumber();

        int num2 = NumberPoolManager.Instance.GetRandomNumber();

        pieceData.SetNumbers(num1, num2);

        Debug.Log($"Generated Piece : {num1} , {num2}");
    }

  
}