using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraXY : MonoBehaviour
{
    public Transform target;
    public float speed;
    public Vector3 offset;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    void LateUpdate()
    {
        //Configuracao da camera
        Vector3 Posicaodesejada = target.position + offset; //posicao desejada e a posicao do objeto mais o espaco da camera X, Y e Z
        Vector3 Posicaosuave = Vector3.Lerp(transform.position, Posicaodesejada, speed); //Posicao suave e feita por interpolacao!!
        transform.position = Posicaosuave; //valor do atributo transform da camera

        // Limitando a posicao da camera nos eixos X e Y
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z); //camera com novo vetor 3D

        // Limitando a posicao do jogador dentro dos limites da tela
        Vector3 Posicaofjogador = target.position; //Box2
        Posicaofjogador.x = Mathf.Clamp(Posicaofjogador.x, minX, maxX);
        Posicaofjogador.y = Mathf.Clamp(Posicaofjogador.y, minY, maxY);
        target.position = Posicaofjogador;
    }
}
