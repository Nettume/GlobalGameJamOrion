using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public static Health InstanceH;
    public Enemy enemy;
    private float health;
    public float HP { get { return health; } set { health = value; } }
    private void Awake()
    {
        InstanceH = this;
    }
    void Start()
    {
        enemy = GameObject.FindWithTag("Enemy").GetComponent<Enemy>();
        health = 3;
    }

    // Update is called once per frame
    void Update()
    {

        switch (health)
        {
            case 1: //enemy.Offset = Vector3.one;
                enemy.offset = 1;
                break;
            case 2: //enemy.Offset =  new Vector3(2,0);
                enemy.offset = 2;
                break; 
            case 3: //enemy.Offset = new Vector3(3,0);
                enemy.offset = 3;
                break;
            default: //enemy.Offset = new Vector3(0,0); 
                enemy.offset = 0;
                break;

        }


    } 


}
