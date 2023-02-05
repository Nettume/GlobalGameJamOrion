using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    Health health;

    private void Start()
    {
        health = Health.InstanceH;
        if (health == null)
        {
            health = GameObject.FindWithTag("Player").GetComponent<Health>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (health == null)
            {
                
                health = GameObject.FindWithTag("Player").GetComponent<Health>();
                health.HP -= 1;
            }
            else
            {
                health.HP -= 1;
            }
            
        }
    }
}
