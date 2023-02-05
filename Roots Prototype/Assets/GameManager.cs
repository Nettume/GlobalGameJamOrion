using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private GameObject Antagonist;
    [SerializeField]
    private Transform startPoint;
    [SerializeField]
    private Transform enemyStartPoint;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        Player = Instantiate(Player, startPoint);
        Antagonist = Instantiate(Antagonist, enemyStartPoint);
        if (Antagonist == null)
        {
            Antagonist = GameObject.FindWithTag("Enemy");
            if (!GameObject.FindWithTag("Enemy"))
            {
                Application.Quit();
            }
        }

        if (Player == null)
        {
            GameObject.FindWithTag("Player");

            if (!GameObject.FindWithTag("Player"))
            {
                Application.Quit();
            }
        }
    }
    private void Start()
    {
        Camera.main.GetComponent<cameraFollow>().target = Player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player == null)
        {
            GameOver();
        }
    }
    public void GameOver()
    {
        
        Application.Quit();
    }
}