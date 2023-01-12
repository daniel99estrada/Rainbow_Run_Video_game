using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{   
    public static bool gameOver;
    bool startingGame; 

    // Start is called before the first frame update
    void Start()
    {
        // Time.timeScale = 0;
        obstManager.speed = 0;
        gameOver = false;
        startingGame = true; 
        GameObject.Find("StartUI").GetComponent<Canvas>().enabled = true;
        GameObject.Find("ScoreUI").GetComponent<Canvas>().enabled = false;
        GameObject.Find("GameOverUI").GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) && startingGame)
        {   
            // Time.timeScale = 1;
            obstManager.speed = 18;
            GameObject.Find("StartUI").GetComponent<Canvas>().enabled = false;
            GameObject.Find("ScoreUI").GetComponent<Canvas>().enabled = true;
            startingGame = false;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow)&& gameOver)
        {
            SceneManager.LoadScene("Game");
        }
    }

    public static void GameOver()
    {   
        obstManager.speed = 0;
        GameObject.Find("GameOverUI").GetComponent<Canvas>().enabled = true;
        gameOver = true;
    } 
}
