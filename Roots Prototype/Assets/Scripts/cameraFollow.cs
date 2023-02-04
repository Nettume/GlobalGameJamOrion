using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset = new Vector3(0,0,-10);
    private float timeElasped;

    public int Duration = 2;

    // Start is called before the first frame update
    void Start()
    {
       // player = GameObject.FindWithTag("Player"); // The player
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector2.Lerp(transform.position, player.transform.position + offset, timeElasped / Duration);
        timeElasped += Time.deltaTime;
            //new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 10);
            
    }
}
