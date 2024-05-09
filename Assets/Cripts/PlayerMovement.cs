using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed; //tạo tốc độ nhân vật
    private Rigidbody2D rigidbody2D; //
    private Vector3 change; //tạo di chuyển 
    private Animator animator; //tạo chuyển động 
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero; // nhân vật bắt đầu từ 0 
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        UpdateAnimationAndMove();
    }
    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharater();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);

        }else
        {
            animator.SetBool("moving", false);
        }
    }

    void MoveCharater()
    {
        rigidbody2D.MovePosition(transform.position + change * speed * Time.deltaTime);
    }
}
