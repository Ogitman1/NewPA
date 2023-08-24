using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraXY : MonoBehaviour
{
    public Transform target; // Referência ao Transform do objeto que a câmera seguirá
    public float speed; // Velocidade de interpolação para a câmera seguir suavemente
    public Vector3 offset; // Deslocamento entre a posição da câmera e a posição do objeto
    public float minX; // Valor mínimo permitido no eixo X
    public float maxX; // Valor máximo permitido no eixo X
    public float minY; // Valor mínimo permitido no eixo Y
    public float maxY; // Valor máximo permitido no eixo Y

    void LateUpdate()
    {
        // Configurando a posição desejada da câmera
        Vector3 Posicaodesejada = target.position + offset;

        // Calculando uma posição suave para a câmera usando interpolação linear (Lerp)
        Vector3 Posicaosuave = Vector3.Lerp(transform.position, Posicaodesejada, speed);

        // Definindo a posição da câmera como a posição suavizada
        transform.position = Posicaosuave;

        // Limitando a posição da câmera nos eixos X e Y
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);

        // Limitando a posição do objeto (alvo) dentro dos limites da tela
        Vector3 Posicaofjogador = target.position;
        Posicaofjogador.x = Mathf.Clamp(Posicaofjogador.x, minX, maxX);
        Posicaofjogador.y = Mathf.Clamp(Posicaofjogador.y, minY, maxY);
        target.position = Posicaofjogador;
    }
}
