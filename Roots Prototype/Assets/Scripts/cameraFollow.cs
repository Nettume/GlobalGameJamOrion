using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public GameObject player;

// Start is called before the first frame update
     void Start()
    {
       // player = GameObject.FindWithTag("Player"); // The player
    }

<<<<<<< HEAD
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 5, player.transform.position.z - 10);
=======
        // Smoothly move the camera towards that target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        //fix the camera so it rearranges itself
>>>>>>> second
    }
}
