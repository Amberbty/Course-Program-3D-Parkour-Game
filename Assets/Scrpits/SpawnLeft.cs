using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLeft : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    private float spawnPosZ = -30;
    float repeatRate = 2;
    public float startDelay = 2;
    private PlayerController playerControllerScript;
    private GameManager gameManager;
    public int pointValue;



    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);//Random.Range(0.5f,2));
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    void SpawnObstacle()
    {        
        if(playerControllerScript.gameOver == false)
        {
            int index = Random.Range(0, obstaclePrefabs.Length);
            Vector3 spawnPos = new Vector3(4.2f, 0.07f, spawnPosZ);
            Instantiate(obstaclePrefabs[index], spawnPos, obstaclePrefabs[index].transform.rotation);
            if(index != 4 && index != 5)
                gameManager.UpdateScore(pointValue);
        }
    }
    
}
