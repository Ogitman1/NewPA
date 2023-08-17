using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reverse : MonoBehaviour
{
    private float direction;
    private SpriteRenderer SpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = Input.GetAxis("Horizontal");

        if(direction > 0)
        {
           SpriteRenderer.flipX = false;
        }
        if(direction < 0)
        {
            SpriteRenderer.flipX = true;
        }
        
    }
}
