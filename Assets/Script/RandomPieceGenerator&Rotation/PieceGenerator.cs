using UnityEngine;
using UnityEngine.UI;

public class PieceGenerator : MonoBehaviour
{
    public static PieceGenerator Instance;

    [SerializeField] private Transform spawnPoint;

    public GameObject piecePrefab;
    private GameObject currentPiece;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GeneratePiece();
    }

    public void GeneratePiece()
    {
        currentPiece = Instantiate(piecePrefab, spawnPoint);

        PieceRotation pieceRotation = currentPiece.GetComponent<PieceRotation>();
        pieceRotation.RotatePiece();

        PieceData pieceData = currentPiece.GetComponent<PieceData>();

        int num1 = NumberPoolManager.Instance.GetRandomNumber();

        int num2 = NumberPoolManager.Instance.GetRandomNumber();
        Color hexA = NumberPoolManager.Instance.GetRandomColor(num1);
        Color hexb = NumberPoolManager.Instance.GetRandomColor(num2);
        pieceData.SetNumbers(num1, num2);
        pieceData.SetColor(hexA,hexb);

        Debug.Log($"Generated Piece : {num1} , {num2}");
    }

  
}