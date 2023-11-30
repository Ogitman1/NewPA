using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov : MonoBehaviour
{
    public float SPEED { get; set; } = 5f;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Vector2 moveDirection;

    private Dictionary<string, bool> AnimConditionsBool = new Dictionary<string, bool>();
    private Dictionary<string, float> AnimConditionsFloat = new Dictionary<string, float>();

    void InitializeValues()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        AnimConditionsFloat.Add("Horizontal", 0f);
        AnimConditionsFloat.Add("Vertical", 0f);
        AnimConditionsBool.Add("Parado", false);
        AnimConditionsBool.Add("andlado", false);
        AnimConditionsBool.Add("andcostas", false);
    }
    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        InitializeValues();
    }

    void SetAnimFloat(string condition, float value)
    {
        if (AnimConditionsFloat.ContainsKey(condition) && !Mathf.Approximately(AnimConditionsFloat[condition], value))
        {
            AnimConditionsFloat[condition] = value;
            animator.SetFloat(condition, value);
        }
    }

    void SetAnimBool(string condition, bool value)
    {
        if (AnimConditionsBool.ContainsKey(condition) && AnimConditionsBool[condition] != value)
        {
            AnimConditionsBool[condition] = value;
            animator.SetBool(condition, value);
        }
    }

    void CalcularVelocidade()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(horizontal, vertical);

        if ( vertical != 0 || horizontal != 0)
        {
            SetAnimFloat("Vertical", vertical);
            SetAnimFloat("Horizontal", horizontal);
            SetAnimBool("Parado", false);

            // Adicione a verificação para movimento lateral
            if (horizontal > 0)
            {
                // Movimento para a direita
                SetAnimFloat("Horizontal", horizontal);
                SetAnimFloat("Vertical", 0);
                SetAnimBool("andlado", true);
                SetAnimBool("andcostas", false);
            }
            else if (horizontal < 0)
            {
                // Movimento para a esquerda
                SetAnimFloat("Horizontal", Mathf.Abs(horizontal));
                SetAnimFloat("Vertical", 0);
                SetAnimBool("andlado", true);
                SetAnimBool("andcostas", false);
            }
            else
            {
                // Não há movimento lateral
                SetAnimFloat("Horizontal", 0);
                SetAnimFloat("Vertical", vertical);
                SetAnimBool("andlado", false);
                SetAnimBool("andcostas", false);
            }
        }
        else
        {
            SetAnimFloat("Horizontal", 0);
            SetAnimFloat("Vertical", 0);
            moveDirection = Vector2.zero;

            // Verifique se há movimento lateral quando a velocidade é zero
            if (horizontal > 0)
            {
                // Movimento para a direita
                SetAnimBool("andlado", false);
                SetAnimBool("andcostas", false);
            }
            else if (horizontal < 0)
            {
                // Movimento para a esquerda
                SetAnimBool("andlado", false);
                SetAnimBool("andcostas", false);
            }

            // Verifique se há movimento vertical quando a velocidade é zero
            if (vertical > 0)
            {
                SetAnimBool("Parfrente", false);
                SetAnimBool("andlado", false);
                SetAnimBool("andcostas", false);
            }
            else if (vertical < 0)
            {
                SetAnimBool("Partras", false);
                SetAnimBool("andlado", false);
                SetAnimBool("andcostas", false);
            }
        }
    }

    void FixedUpdate()
    {
        Vector3 movePosition = (SPEED * Time.fixedDeltaTime * moveDirection.normalized) + rb.position;
        rb.MovePosition(movePosition);

        // Pare de calcular a velocidade quando a velocidade for zero
        if (Mathf.Approximately(rb.velocity.magnitude, 0f))
        {
            SetAnimFloat("Horizontal", 0);
            SetAnimFloat("Vertical", 0);
            SetAnimBool("andlado", false);
            SetAnimBool("andcostas", false);
            SetAnimBool("ParLado", false);
            SetAnimBool("Parfrente", false);
            SetAnimBool("Partras", false);
            SetAnimBool("Parado", true);
        }
        else
        {
            CalcularVelocidade();
        }
    }
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


