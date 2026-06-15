using UnityEngine;
using UnityEngine.UI;

public class PieceData : MonoBehaviour
{
    public int firstNumber;
    public int secondNumber;
    [SerializeField] private Text num1text, num2text;

    public void SetNumbers(int a, int b)
    {
        firstNumber = a;
        secondNumber = b;
        num1text.text = a.ToString();
        num2text.text = b.ToString();
    }
}