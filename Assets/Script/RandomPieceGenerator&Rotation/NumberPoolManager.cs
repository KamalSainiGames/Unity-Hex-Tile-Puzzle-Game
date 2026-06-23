using System.Collections.Generic;
using UnityEngine;

public class NumberPoolManager : MonoBehaviour
{
    public static NumberPoolManager Instance;

    private List<int> availableNumbers = new List<int>();
    private List<Color> availableColors = new List<Color>();

    private void Awake()
    {
        Instance = this;

        // Number Pool
        availableNumbers.Add(1);
        availableNumbers.Add(2);
        availableNumbers.Add(3);

        // Color Pool
        availableColors.Add(Color.green);
        availableColors.Add(Color.blue);
        availableColors.Add(Color.red);
    }

    public int GetRandomNumber()
    {
        int index = Random.Range(0, availableNumbers.Count);
        return availableNumbers[index];
    }

    public Color GetRandomColor(int index)
    {        
        return availableColors[index-1];
    }

    public void AddNumberToPool(int number)
    {
        if (!availableNumbers.Contains(number))
        {
            availableNumbers.Add(number);
        }
    }

    public void AddColorToPool(Color color)
    {
        if (!availableColors.Contains(color))
        {
            availableColors.Add(color);
        }
    }
}