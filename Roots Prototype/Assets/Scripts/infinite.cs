using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infinite : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 200f;
    private Transform placeHolder;
    private Transform lastStartPoint;
    private Transform lastFromPoint;
    private Vector3 lastEndPosition;
    private  Transform levelPart_Start;
    private Transform player;

    void Start() 
    {
        lastEndPosition = levelPart_Start.Find("EndPosition").position;
        SpawnLevelPart();
    }
    private void FixedUpdate()
    {
        if (Vector3.Distance(player.transform.position, lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
        {
            SpawnLevelPart();
        }
    }
    private void SpawnLevelPart()
    {
        Transform lastLevelPartTransform = InstantiateLevelPart(lastStartPoint.Find("EndPosition").position);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }
    private Transform InstantiateLevelPart(Vector3 spawnPoints)
    {
        Transform lastPartPoint = Instantiate(placeHolder, spawnPoints, Quaternion.identity);
        return lastPartPoint;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
