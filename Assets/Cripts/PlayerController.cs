using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    
    public float speed = 0.5f;
    Rigidbody2D rigidbody2D;
    private Vector2 input;
    Animator animator;
    private Vector2 lastMoveDirection;
    private bool facingLeft = true;
    public VectorValue startingPosition;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        
        animator = GetComponent<Animator>();
        transform.position = startingPosition.initialValue;
    }

    // Update is called once per frame
    void Update()
    {
        //proccessInput
        ProccessInputs();
        //Animate
        Animate();
        // flip
        if(input.x < 0 && !facingLeft || input.x > 0 && facingLeft)
        {
            Flip();
        }
        

    }
    private void FixedUpdate()
    {
        rigidbody2D.velocity=input * speed;
    }
    void ProccessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if((moveX == 0 && moveY == 0) && (input.x !=0 || input.y !=0))
        {
            lastMoveDirection = input;
        }

        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        input.Normalize();
    }
    void Animate()
    {
        animator.SetFloat("MoveX", input.x);
        animator.SetFloat("MoveY", input.y);
        animator.SetFloat("MoveMagnitude", input.magnitude);
        animator.SetFloat("LastMoveX", lastMoveDirection.x);
        animator.SetFloat("LastMoveY", lastMoveDirection.y);

    }
    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= 1;
        transform.localScale = scale;
        facingLeft = !facingLeft;
    }
}
