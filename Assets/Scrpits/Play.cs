using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Play : MonoBehaviour
{
    private Button play;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        play = GetComponent<Button>();
        play.onClick.AddListener(StartGame);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void StartGame()
    {
        Debug.Log(gameObject.name + " was clicked");
        gameManager.StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
