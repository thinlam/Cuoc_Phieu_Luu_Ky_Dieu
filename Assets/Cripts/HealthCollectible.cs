using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth controller = other.GetComponent<PlayerHealth>();

        if(controller != null && controller.health < controller.maxHealth)
        {
            controller.ChangeHealth(1);
            Destroy(gameObject);
        }
    }
    
}
