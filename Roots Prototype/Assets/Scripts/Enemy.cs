using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Transform Target;
    Rigidbody2D rg2D;
    private float speed = 5;
    public Vector2 offset = Vector3.zero;
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
    private void Update()
    {
        difference = Jump() - transform.position.y;
        if (difference != 0)
        {
            Leap(difference);
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

        Debug.Log(Vector2.Distance(Target.position, transform.position) >= 3f);
        if (Vector2.Distance(Target.position, transform.position) >= 3f){
            Debug.Log(Follow() - offset);
            rg2D.velocity = Follow() - offset;
        }
        else
        {
            Debug.Log("YEs");
            transform.Translate(Target.position - Vector3.right);
        }
    }

    private Vector2 Follow()
    {
        //Possibly follow target x
        return new Vector2( 1 * speed , Jump());
        
    }
    private float Jump() //Moves the enemy in the same y direction as the player - a jump when the player jumps
    {
        return Target.position.y ; 
    }
    
    private void Leap(float dif)
    {
        rg2D.AddForce(new Vector2(0,dif), ForceMode2D.Force);
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
    }
}
