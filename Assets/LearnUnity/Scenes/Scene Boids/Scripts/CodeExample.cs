using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeExample : MonoBehaviour
{
    public int numTimesCalled = 0;
    int numA, numB;
    
    void Awake()
    {
        int num = Add(5, 5);
        Debug.Log(num);
        Debug.Log(Add(1, 2, 3, 4, 5, 6, 7, 8, 9, 10));

        Debug.Log(Fac(5));
        Debug.Log(Fac(0));
        Debug.Log(Fac(-5));
    }

    int Add(int numA, int numB)
    {
        int sum = numA + numB;
        return (sum);
    }
    
    int Add(params int[] ints)
    {
        int sum = 0;
        foreach(int i in ints)
        {
            sum += i;
        }
        return (sum);
    }

    int Fac(int n)
    {
        if(n < 0) { return (0); }

        if(n == 0) { return (1); }

        int result = n * Fac(n - 1);
        return (result);

    }

    void Update() => numTimesCalled++;//PrintUpdates();

    private void PrintUpdates()
    {
        string outputMessage = "Update: " + numTimesCalled;
        Debug.Log(outputMessage);
    }
}
