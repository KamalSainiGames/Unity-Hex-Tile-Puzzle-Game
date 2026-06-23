using UnityEngine;
using UnityEngine.EventSystems;

public class PieceDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;

    private Vector2 startPosition;

    [SerializeField] private float dragOffsetY = 80f;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }
    public static bool IsDrag = false;
    public void OnBeginDrag(PointerEventData eventData)
    {
        IsDrag = true;
        startPosition = rectTransform.anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;

        // Piece mouse/finger se thoda upar
        rectTransform.anchoredPosition += Vector2.up * (dragOffsetY * Time.deltaTime);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // rectTransform.anchoredPosition = startPosition;

        IsDrag = false;
        PieceRotation rotation = GetComponent<PieceRotation>();

        TileScript tileA = PlacementManager.Instance.GetNearestTile(transform.position);

        TileScript tileB = PlacementManager.Instance.GetNeighbourTile(tileA, rotation.RotationIndex);

        bool valid = PlacementManager.Instance.IsValidPlacement(tileA, tileB);

        if (valid)
        {
            PlacementManager.Instance.PlacePiece(tileA,tileB,gameObject);
        }
        else
        {
            rectTransform.anchoredPosition = startPosition;
        }
    }
}