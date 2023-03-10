using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protagonist : MonoBehaviour
{
    const int GROUND_RADIUS = 3;
    float movX = 0;
    float movY = 0;
    public float speed = 3f;

    public bool isGrounded = false;
    public Transform groundPos;
    public LayerMask ground; 

    Rigidbody2D rigid;
    Vector2 direction;
<<<<<<< HEAD:Roots Prototype/Assets/Scripts/Protagnist.cs
    public float jumpHeight;

=======
    public float jumpHeight = 5f;
    GameManager gameManager;
>>>>>>> second:Roots Prototype/Assets/Scripts/Protagonist.cs
    // Start is called before the first frame update
    private void Awake()
    {
        gameManager = GameManager.Instance;
        if (gameManager == null)
        {
           gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        }
        rigid = transform.GetComponent<Rigidbody2D>();
        rigid.gravityScale = rigid.gravityScale * 10;
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
    public Vector2 Jump()
    {
        Debug.Log(isGrounded);
        isGrounded = Physics2D.OverlapCircle(groundPos.position, GROUND_RADIUS, ground);
        if (isGrounded == true)
        {
            Vector2 leap = Vector2.up * jumpHeight;
            return leap;
        }
        else
        {
            return Vector2.zero;
        }
    }
    private void OnDestroy()
    {
        //Application.Quit()
        gameManager.GameOver();

    }
}
