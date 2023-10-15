using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{

    public float speed = 30;
    private Vector3 move = new Vector3(0, 0, 1);
    private PlayerController PlayerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerControllerScript.gameOver == false)
            transform.Translate(move * Time.deltaTime * speed);
        if(transform.position.z > 250 && gameObject.CompareTag("Environment"))
            Destroy(gameObject);
    }
}
