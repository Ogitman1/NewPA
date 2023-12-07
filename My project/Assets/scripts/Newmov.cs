using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newmov : MonoBehaviour
{
    public float SPEED { get; set; } = 5f;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Vector2 moveDirection;
    public float distanceToMove = 0.5f; // Distância para verificar colisões

    private Dictionary<string, bool> AnimConditionsBool = new Dictionary<string, bool>();
    private Dictionary<string, float> AnimConditionsFloat = new Dictionary<string, float>();

    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.interpolation = RigidbodyInterpolation2D.Interpolate; 
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        InitializeValues();
    }

    void InitializeValues()
    {
        AnimConditionsFloat.Add("Horizontal", 0f);
        AnimConditionsFloat.Add("Vertical", 0f);
        AnimConditionsFloat.Add("Speed", 0f);
        AnimConditionsBool.Add("andlado", false);
        AnimConditionsBool.Add("andcostas", false);
        AnimConditionsBool.Add("andfrente", false);
        AnimConditionsBool.Add("Parado", false);
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
        Vector2 newMoveDirection = new Vector2(horizontal, vertical).normalized;
    
        //bool mudouDirecao = (horizontal != 0 || vertical != 0) && (newMoveDirection.x == horizontal || newMoveDirection.y == vertical);
        // Se houver uma colisão, ajustar o movimento
        if (newMoveDirection != Vector2.zero && newMoveDirection != moveDirection)
        {
            Debug.Log("Foi");
            moveDirection = newMoveDirection;
            
        }
        RaycastHit2D hit = Physics2D.Raycast(rb.position, moveDirection, distanceToMove);
        if (hit.collider != null)
        {
            Debug.Log("Colidiu");
             moveDirection = Vector2.zero;
             SPEED = 0f;
        }
            
        else{
            Debug.Log("Saiu");
            newMoveDirection = new Vector2(horizontal, vertical).normalized;
            SPEED = 5f;
        }
            SetAnimFloat("Vertical", Mathf.Abs(vertical));
            SetAnimFloat("Horizontal", Mathf.Abs(horizontal));
            SetAnimBool("Parado", false);

            if (horizontal > 0)
            {
                SetAnimBool("andlado", true);
                SetAnimBool("andcostas", false);
                SetAnimFloat("Speed", 5f);
            }
            else if (horizontal < 0)
            {
                SetAnimBool("andlado", true);
                SetAnimBool("andcostas", false);
                SetAnimFloat("Speed", 5f);
            }
            else if(vertical > 0)
            {
                SetAnimBool("andlado", false);
                SetAnimBool("andcostas", true);
                SetAnimFloat("Speed", 5f);
            }
            else if(vertical < 0)
            {
                SetAnimBool("andlado", false);
                SetAnimBool("andcostas", false);
                SetAnimBool("andfrente", true);
                SetAnimFloat("Speed", 5f);
            }
        
        else
        {
            SetAnimFloat("Horizontal", horizontal);
            SetAnimFloat("Vertical", vertical);
           // newMoveDirection = Vector2.zero;

            if (horizontal > 0)
            {
                SetAnimBool("andlado", false);
                SetAnimBool("andcostas", false);
                SetAnimBool("andfrente", false);
                SetAnimBool("Parado", true);
                SetAnimFloat("Speed", 0f);
            }
            else if (horizontal < 0)
            {
                SetAnimBool("andlado", false);
                SetAnimBool("andcostas", false);
                SetAnimBool("andfrente", false);
                SetAnimBool("Parado", true);
                SetAnimFloat("Speed", 0f);
            
            }
            else
            {
                SetAnimBool("Parado", false);
                SetAnimFloat("Speed", 5f);
                SetAnimBool("andcostas", false);
                SetAnimBool("andfrente", false);
                
            }

            if (vertical > 0)
            {
                SetAnimBool("Parado",true);
                SetAnimFloat("Speed", 0f);
                SetAnimBool("andcostas", false);
                SetAnimBool("andfrente", false);
                SetAnimBool("andfrente", false);
            }
            else if (vertical < 0)
            {
                
                SetAnimBool("Parado",true);
                SetAnimFloat("Speed", 0f);
                SetAnimBool("andcostas", false);
                SetAnimBool("andfrente", false);
            }
            else
            {
                SetAnimBool("Parado",true);
                SetAnimFloat("Speed",0f);
                SetAnimBool("andlado", false);
            }
        }
        rb.MovePosition(rb.position + moveDirection * Time.deltaTime * SPEED);
    }

    void FixedUpdate()
    {
        CalcularVelocidade();
    }
}