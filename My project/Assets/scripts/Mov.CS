using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov : MonoBehaviour
{ //Passo 1 - Declaração das manipulações de variaveis
    public float SPEED { get; set; } = 5f; //Velocidade de personagem
    [SerializeField]
    private Animator animator; //Propriedade Animator
    [SerializeField]
    private Rigidbody2D rb; //Colisões 2D
    [SerializeField]
    private Vector2 moveDirection; //Fisica 2D
    
    //Passo 2 - Pegar o componente das váriáveis rb e animator
    //Método Awake começa antes do método Start
    void Awake () {
        // Obtém o componente Animator do objeto
        animator = GetComponent<Animator>();
         rb = GetComponent<Rigidbody2D>();
    }

    //Passo 3 - Manipulação das váriaveis no Update()
    void Update()
    {
        // Obtém as entradas do jogador para a velocidade e direção
        float horizontal = Input.GetAxisRaw("Horizontal"); //eixo Horizontal
        float vertical = Input.GetAxisRaw("Vertical"); //eixo Vertical

        if(vertical!= 0 || horizontal != 0)
        {
            // Calcula direções dos eixos y e x
            moveDirection = new Vector2(horizontal, vertical);
            // Define a velocidade para acionar a animação de movimento
            animator.SetFloat("Vertical", SPEED);
            
            // Define a direção para acionar a animação de movimento na direção correta
            animator.SetFloat("Horizontal", horizontal);
            animator.SetFloat("Vertical", vertical);

        }
        
        else{
            moveDirection = Vector2.zero; 
             animator.SetFloat("Vertical", 0);
             animator.SetFloat("Horizontal", 0);
        }
    }
    //Passo 4 - Manipulação do Vector3 para que o personagem ande em todas as direções
 private void FixedUpdate()
    {
        Vector3 movePosition = (SPEED * Time.fixedDeltaTime * moveDirection.normalized) + rb.position;
        rb.MovePosition(movePosition);
       // HandleMovement();
    }
    /*
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
        
       Vector3 movePosition = (SPEED * Time.fixedDeltaTime * moveDirection.normalized) + rb.position;
        rb.MovePosition(movePosition);
    
    }
    */
}

