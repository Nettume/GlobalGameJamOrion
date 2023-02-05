using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    float health;

    Enemy enemy;
    void Start()
    {
        health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        switch (health)
        {
            case 1: enemy.offset = Vector2.one;
                break;
            case 2: enemy.offset =  new Vector2(1,0);
                break; 
            case 3: enemy.offset = new Vector2 (3,0);
                break;
            default: enemy.offset = new Vector3(0,0); break;

        }


    } 


}
