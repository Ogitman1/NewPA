using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    public Transform Box2;
    public float minX, maxX;
    
    public void FixedUpdate()
    {
        Vector3 newposition = Box2.position + new Vector3(0,0, -10);/* novo variavel Vector3 chamado newposition que pega 
        a posicao do jogador, nesse caso Box2, e ajusta a propriedade Z da camera para filmagem */
        newposition.y = -0.76f; // pega a variavel newposition e ajusta a posicao y da camera
        transform.position = newposition; // passa o valor da variavel newposition e atibui ela a propriedade transform da camera 

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y, transform.position.z);
        //atribui o valor minimo e maximo de x
    }
}
