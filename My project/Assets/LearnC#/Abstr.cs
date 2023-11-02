using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abstr : MonoBehaviour
{
    
    public abstract class Vilões
{

    public int poder, forca, velocidade;

    public Vilões(int poder, int forca, int velocidade)
    {
        this.poder = poder;
        this.forca = forca;
        this.velocidade = velocidade;
    }

    public abstract void ShowDamage(int damage);
}

       sealed class Dracula : Vilões
    {
        public Dracula(int p, int f, int v) : base(p, f, v)
        {
        }
       public override void ShowDamage(int damage)
    {
        Debug.Log("Damage: " + damage);
    }
    }

    void Start()
{
    Dracula Dracs = new Dracula(100, 70, 20);
    Dracs.ShowDamage(Dracs.poder);
}


    
}
