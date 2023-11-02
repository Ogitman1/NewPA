using UnityEngine;
using System;

public class Vilão : MonoBehaviour
{
    public delegate void EnemyDeath(); //delegate
    public static event EnemyDeath OnEnemyDied; //evento associado ao delegate
    public new int enemylife = 10;

    void Start()
    {
        // You typically don't invoke events in the Start method.
        // The event should be invoked when the enemy's life reaches 0.
        
        Check(enemylife);
         
    }
    void Update()
    {
        TakeDamage(10);
    }
    public void Check(int num)
    {
        switch(num){
            case 0: Debug.Log("Enemylife is 0"); break;
            case 10: Debug.Log("Enemylife is 10"); break;
            case -5: Debug.Log("Enemylife is -5"); break;
        }
    }
    public void TakeDamage(int damage)
    {
        enemylife -= damage;
        Debug.Log(enemylife);
        if (enemylife <= 0)
        {
            // Check if the event has subscribers before invoking it.
            if(OnEnemyDied != null)
            {
                OnEnemyDied();
            }
        }
    }
}
