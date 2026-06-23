using UnityEngine;
using UnityEngine.EventSystems;

public class PieceRotation : MonoBehaviour, IPointerClickHandler
{
    public RectTransform hexA;
    public RectTransform hexB;

    private int rotationIndex = 0;
    public int RotationIndex => rotationIndex;

    private Vector2[] hexAPos =
    {
        new Vector2(-65,-65),
        new Vector2(-80,-15),
        new Vector2(-40,60),
        new Vector2(20,70),
        new Vector2(90,-15),
        new Vector2(45,-75)
    };

    private Vector2[] hexBPos =
    {
        new Vector2(20,70),
        new Vector2(90,-15),
        new Vector2(45,-75),
        new Vector2(-65,-65),
        new Vector2(-80,-15),
        new Vector2(-40,60)
    };

  

    public void RotatePiece()
    {
        rotationIndex = (rotationIndex + 1) % 6;
        ApplyRotation();
    }

    private void ApplyRotation()
    {
        hexA.localPosition = hexAPos[rotationIndex];
        hexB.localPosition = hexBPos[rotationIndex];
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!PieceDrag.IsDrag)
        {
            RotatePiece();
        }
      
    }
}