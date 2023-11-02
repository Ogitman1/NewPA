using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class St : MonoBehaviour
{
    abstract class Enemies{
	int forca, poder, velocidade;
	public Enemies(int poder, int forca, int velocidade){
	this.poder = poder;
	this.forca = forca;
	this.velocidade = velocidade;
}
	public abstract void Power(); 
} 
sealed class Simpleenemy : Enemies{
	public Simpleenemy(int poder, int velocidade, int forca) : base(poder, velocidade, forca)
    {}
    public override void Power(){
	Debug.Log(1);
}


}

void Start(){
    Simpleenemy enemy = new Simpleenemy(10, 5, 3);
    enemy.Power();
}
}
