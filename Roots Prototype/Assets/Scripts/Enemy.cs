using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Transform Target;
    Rigidbody2D rg2D;
    private float speed = 5;
    public Vector2 Offset { get { return ffset; } set { ffset = value; } }
    private Vector2 ffset = Vector3.zero;
    public float offset;
    float difference;

    private void Awake()
    {
        Target = GameObject.FindWithTag("Player").transform;
        rg2D = gameObject.GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (Target.gameObject.activeInHierarchy)
        { 
           
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Target.gameObject.activeInHierarchy)
        {
            Chase();
        }
    }
    //Running Script
    void Chase()
    {
        Vector3 teleport = Target.Find("EnemyPos").position;
        if (Vector2.Distance(Target.position, transform.position) <= 50f) { 
            rg2D.velocity = Follow();
            //Debug.Log(Follow() - offset);
        }
        else
        {
            transform.position = teleport;
        }
    }

    private Vector2 Follow()
    {
        //Possibly follow target x
<<<<<<< HEAD
        return (Target.position - transform.position) * speed;
=======
        return new Vector2((1 * speed) - offset, Jump());//1 * speed , Jump());

    }
    private float Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rg2D.AddForce(Vector2.up * 100, ForceMode2D.Impulse);
        }
        return 0;
    }
    private void Capture(Transform player) // removes the player IE GAMEOVER!!
    {
       Destroy(player.gameObject);
    }

    //Checks if the player has collider with the enemy
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.name == Target.name) //uses the player name as verification
        {
            Capture(collision.collider.transform);
        }
>>>>>>> second
    }
}
