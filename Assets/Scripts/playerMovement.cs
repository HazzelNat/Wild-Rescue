using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed;
    float horizontal;
    float vertical;
    private Animator animator;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if (horizontal != 0 || vertical != 0){
            animator.SetFloat("speed", 8);
        }
        else if (horizontal == 0 & vertical == 0){
            animator.SetFloat("speed", 0);
        }
        

        bool flipped = horizontal > 0;
        this.transform.rotation = Quaternion.Euler(new Vector3 (0f, flipped ? 180f : 0f, 0f));
    }

    private void FixedUpdate()
    {  
        rb2d.velocity = new Vector2(horizontal * speed, vertical * speed);
    }
}
