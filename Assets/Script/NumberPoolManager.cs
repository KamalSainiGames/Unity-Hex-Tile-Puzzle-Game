using System.Collections.Generic;
using UnityEngine;

public class NumberPoolManager : MonoBehaviour
{
    public static NumberPoolManager Instance;

    private List<int> availableNumbers = new List<int>();

    private void Awake()
    {
        Instance = this;

        availableNumbers.Add(1);
        availableNumbers.Add(2);
        availableNumbers.Add(3);
    }

    public int GetRandomNumber()
    {
        int index = Random.Range(0, availableNumbers.Count);
        return availableNumbers[index];
    }

    public void AddNumberToPool(int number)
    {
        if (!availableNumbers.Contains(number))
        {
            availableNumbers.Add(number);
        }
    }
}