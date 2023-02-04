using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Transform Target;
    Rigidbody2D rg2D;
    private float speed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        rg2D = gameObject.GetComponent<Rigidbody2D>(); 
        if (Target.gameObject.activeInHierarchy)
        { 
           
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(Follow());
        if (Target.gameObject.activeInHierarchy)
        {
            Chase();
        }
    }
    //Running Script
    void Chase()
    {
        rg2D.velocity = Follow();
    }

    private Vector2 Follow()
    {
        //Possibly follow target x
       return new Vector2((Target.position.x - transform.position.x) * speed, Jump());
    }
    private float Jump()
    {
        return (Target.position.y - transform.position.y);
    }
}
