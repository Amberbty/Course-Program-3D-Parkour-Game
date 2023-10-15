using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI disText;
    //public TextMeshProUGUI gameOverText;
    private PlayerController playerController;
    public Button restartButton;
    public Button gameOver;
    private bool gameover;
    public GameObject title;
    public Image back;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Distance(0));
        UpdateScore(0);
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        gameover = playerController.gameOver;
        title.gameObject.SetActive(false);
        back.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameOver()
    {
        //gameOverText.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        gameover = playerController.gameOver;
        //disText.text = "Distance: " + distance;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator Distance(int dis)
    {
        while(gameover == false)
        {
            Debug.Log("Game Over is : " + gameover);
            yield return new WaitForSeconds(1);
            dis += 10;
            disText.text = "Distance: " + dis;
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    
}
