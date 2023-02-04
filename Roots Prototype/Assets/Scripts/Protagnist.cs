using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protagnist : MonoBehaviour
{
    const int GROUND_RADIUS = 1 / 2;
    float movX = 0;
    float movY = 0;
    float speed = 3f;

    public bool isGrounded = false;
    public Transform groundPos;
    public LayerMask ground; 

    Rigidbody2D rigid;
    Vector2 direction;
    public float jumpHeight = 5f;

    // Start is called before the first frame update
    private void Awake()
    {
    }
    void Start()
    {
         rigid = transform.GetComponent<Rigidbody2D>();
        //Starting the gamme by calling his gameBody, position and future position
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Running(); //The running script is always running leading to an endless runner
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigid.AddForce(Jump(), ForceMode2D.Impulse);
        }
    }

    //Runner Module
    void Running()
    {
        rigid.velocity = Direction(Vector2.right) * speed;
    }


    //Infinite Run Fun
    private Vector2 Direction(Vector2 dir)
    {
         //the limit of getAxis is that movmenet is either -1 or 1, so to increase speed * speed or += direction
        direction = new Vector2(movX, 0);
        return direction += dir;
        // button presses sets the direction in a trasnform for the character to move
        //setting the direction sets the axis and rotation
    }

    //Axis Fun
     private Vector2 GetAxis()
        {
        //the limit of getAxis is that movmenet is either -1 or 1, so to increase speed * speed or += direction
        movX = Input.GetAxis("Horizontal");
        movY = Input.GetAxis("Vertical");
        Vector2 axisDir = new Vector2(movX + 2, movY);
        return axisDir *= speed ;
    }   
  

    //Jump Module
    private Vector2 Jump()
    {
        Debug.Log(isGrounded);
        isGrounded = Physics2D.OverlapCircle(groundPos.position, GROUND_RADIUS, ground);
        if (isGrounded)
        {
            Vector2 leap = Vector2.up * jumpHeight;
            Debug.Log(leap);
            return leap;
        }
        else
        {
            return Vector2.zero;
        }
    }
}
