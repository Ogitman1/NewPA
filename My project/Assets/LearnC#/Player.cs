using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       Vilão.OnEnemyDied += Comemorar;
    }

    void Comemorar()
    {
        Debug.Log("Comemorando a derrota do inimigo");
    }
}
