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

    private Dictionary<string, bool> AnimConditionsBool = new Dictionary<string, bool>();
    private Dictionary<string, float> AnimConditionsFloat = new Dictionary<string, float>();

    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
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
        moveDirection = new Vector2(horizontal, vertical);

        if (vertical != 0 || horizontal != 0)
        {
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
        }
        else
        {
            SetAnimFloat("Horizontal", horizontal);
            SetAnimFloat("Vertical", vertical);
           // moveDirection = Vector2.zero;

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
    }

    void FixedUpdate()
    {
        Vector3 movePosition = (SPEED * Time.fixedDeltaTime * moveDirection.normalized) + rb.position;
        rb.MovePosition(movePosition);
        CalcularVelocidade();
    }
}
