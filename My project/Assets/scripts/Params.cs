using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Params : MonoBehaviour
{
    int soma;
    void Start()
    {
        soma = Soma(12, 13, 19, 8);
        Debug.Log(soma);
    }

    public int Soma(params int [] array)
    {
        int resultado = 0;
        for (int i = 0; i < array.Length; i++){
            resultado += array[i];
        }
        return resultado;
    }
}
