using UnityEngine;
using UnityEngine.UI;

public class PieceData : MonoBehaviour
{
    public int firstNumber;
    public int secondNumber;
    public Color hexa, hexb;

    [SerializeField] private Text num1text, num2text;
    [SerializeField] private Image HexAImage, HexBImage;

    public void SetNumbers(int a, int b)
    {
        firstNumber = a;
        secondNumber = b;
        num1text.text = a.ToString();
        num2text.text = b.ToString();
    }

    public void SetColor(Color a,Color b)
    {
        hexa = a;
        HexAImage.color = hexa;
        hexb = b;
        HexBImage.color = hexb;
    }
}