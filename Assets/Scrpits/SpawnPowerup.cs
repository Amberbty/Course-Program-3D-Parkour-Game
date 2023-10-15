using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerup : MonoBehaviour
{
    public GameObject powerupPrefab;
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GenerateSpawnPosition", 2, 10);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateSpawnPosition()
    {
        if(playerControllerScript.gameOver == false)
        {
            float posX = Random.Range(-6.2f, 6.2f);
            Vector3 powerPos = new Vector3(posX, 0.11f, -45);
            Instantiate(powerupPrefab, powerPos, powerupPrefab.transform.rotation);
        }
        
    }
}
