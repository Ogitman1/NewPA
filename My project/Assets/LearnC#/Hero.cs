using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    //    Villain.OnEnemyDied += Comemorar;
    }
    public void Comemorar()
    {
        Debug.Log("Ganhamos!!!");

    }
}
