using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerHealth: MonoBehaviour
{
    
    
    public int maxHealth = 5;
    int currentHealth=1;
    
    
    
    public int health { get { return currentHealth; } }

    // Start is called before the first frame update
    void Start()
    {
        
       
        
        //currentHealth = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    
    void FixedUpdate()
    {
       
    }
    public void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}
