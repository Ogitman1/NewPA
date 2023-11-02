using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Out : MonoBehaviour
{
    int som, subtração;
    void Start()
    {
        som = Soma(13, 13, out subtração);
        Debug.Log(som);
        Debug.Log(subtração);
    }

    int Soma(int a, int b, out int c)
    {
        c = a-b;
        return a + b;
    }
}
