using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    public int maxHealth = 5;
    int currentHealth=1;
    public float speed = 6.0f;
    Vector2 move;
    public InputAction MoveAction;
    public int health { get { return currentHealth; } }

    // Start is called before the first frame update
    void Start()
    {
        
        MoveAction.Enable();
        rigidbody2D = GetComponent<Rigidbody2D>();
        //currentHealth = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        move = MoveAction.ReadValue<Vector2>();
        
    }
    
    void FixedUpdate()
    {
        Vector2 position = (Vector2)rigidbody2D.position + move * speed * Time.deltaTime;
        rigidbody2D.MovePosition(position);
    }
    public void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}
