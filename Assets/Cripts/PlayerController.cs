using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    public float speed = 6.0f;
    Rigidbody2D rigidbody2D;
    private Vector2 input;
    private Vector2 lastMoveDirection;
    private bool facingleft = true;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //proccessInput
        ProccessInputs();
        //Animate
        Animate();
        // flip
        if(input.x <0 && !facingleft || input.x >0 && facingleft)
        {
            Flip();
        }
        

    }
    void FixedUpdate()
    {
        rigidbody2D.velocity = input* speed;
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
        scale.x *= -1;
        transform.localScale = scale;
        facingleft = !facingleft;
    }
}
