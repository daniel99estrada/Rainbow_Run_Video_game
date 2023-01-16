using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{   
    public static bool gameOver;
    bool GameInProgress; 

    public static Canvas GameOverUI;
    public static Canvas StartUI;
    public static Canvas ScoreUI;

    void Awake()
    {
        StartUI = GameObject.Find("StartUI").GetComponent<Canvas>();
        GameOverUI = GameObject.Find("GameOverUI").GetComponent<Canvas>();
        ScoreUI = GameObject.Find("ScoreUI").GetComponent<Canvas>();

        obstManager.speed = 0;
        gameOver = false;
        GameInProgress = false; 
    }

    // Start is called before the first frame update
    void Start()
    {
        SetStartScreenUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) && !GameInProgress)
        {   
            obstManager.speed = obstManager.initialSpeed;

            GameInProgress = true;

            SetInGameUI ();

        }

        if (Input.GetKeyDown(KeyCode.DownArrow)&& gameOver)
        {
            SceneManager.LoadScene("Game");
        }
    }

    public static void GameOver()
    {   
        gameOver = true;
        obstManager.speed = 0;

        GameOverUI.enabled = true;
        ScoreUI.enabled = false;

        GameObject.Find("GameOverUI").GetComponent<GameOverAnimationManager>().playAnimations();
    } 

    void SetStartScreenUI()
    {
        StartUI.enabled = true;
        ScoreUI.enabled = false;
        GameOverUI.enabled = false;
    }

    void SetInGameUI ()
    {
        StartUI.enabled = false;
        ScoreUI.enabled = true;
    }
}
