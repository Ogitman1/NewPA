using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delegates : MonoBehaviour
{
    delegate void exemplodel();
    exemplodel Variaveldel;
    
    void Start()
    {
        Variaveldel = atq;
        Variaveldel += pulo;
        Variaveldel += defesa;
        Variaveldel();
    }
    void atq()
    {
        Debug.Log("1");
    }
    void pulo()
    {
        Debug.Log("2");
    }
    void defesa()
    {
        Debug.Log("3");
    }
}
