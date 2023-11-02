using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Villain : MonoBehaviour
{
    public delegate void EnemyDeath();
    public static event EnemyDeath OnEnemyDied;
    public int enemylife = 10;
    void Start()
    {
        
        TakeDamage();
        Check();
    }

    public void TakeDamage(){
        for(int i = 0; i < 10; i++)
        {
            enemylife -= 1;
            if(enemylife == 0){
            Hero Myhero = new Hero();
            OnEnemyDied += Myhero.Comemorar;
            OnEnemyDied?.Invoke();
        }
        }
        
       
    }
    public void Check(){
        if(OnEnemyDied == null)
        {
            Debug.Log("Error: OnemmyDied is null");
        }

    } 
}
