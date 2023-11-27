using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov : MonoBehaviour
{
    public float SPEED { get; set; } = 5f;
    private float direcao;
    private Animator animator;

     void Start()
    {
        // Obtém o componente Animator do objeto
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Obtém as entradas do jogador para a velocidade e direção
        SPEED = Input.GetAxis("Vertical");
        direcao = Input.GetAxis("Horizontal");
        HandleMovement();
        
        if(SPEED != 0 || direcao != 0)
        {
            // Define a velocidade para acionar a animação de movimento
            animator.SetFloat("Speed", Mathf.Abs(SPEED));
            
            // Define a direção para acionar a animação de movimento na direção correta
            animator.SetFloat("Direcao", direcao);
        }
        else{
             animator.SetFloat("Speed", 0);
        }
    }

    public void HandleMovement()
    {
        // variaveis para poder adiciona velocidade no eixo x e y
        float moveX = 0f;
        float moveY = 0f;
        if (Input.GetKey(KeyCode.W) ||  Input.GetKey(KeyCode.UpArrow)) //se aperta w ou a seta ^ vai pra cima
        {
            moveY = +1f;
        }
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) //se aperta S ou a seta pra baixo vai pra baixo
        {
            moveY = -1f;
        }
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) //se aperta A ou a seta pro lado vai pra esquerda
        {
            moveX = -1f;
        }
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) //se aperta D ou a seta pra direita vai pra direita
        {
            moveX = +1f;
        }
        Vector3 moveDir = new Vector3(moveX, moveY).normalized; // instancia do vector3 para o personagem poder andar pelas diagonais
        transform.position += moveDir * SPEED * Time.deltaTime; // calcula direção, a velocidade e o tempo respectivamente
        
    
    }
    
}
