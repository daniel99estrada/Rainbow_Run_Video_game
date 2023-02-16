using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{      
    public static bool gameOver;
    public static bool gameInProgress; 
    public int initialSpeed;
    public bool startingGame;

    void Awake()
    {
        obstManager.speed = 0;
        gameOver = false;
        gameInProgress = false;
        startingGame = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        UIManager.SetStartScreenUI();
        Invoke("StartGame", 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameInProgress &&  startingGame)
        {   
            // Wait for input.
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || SwipeManager.tap)
            {   
                gameInProgress = true;

                //set objects in motion
                obstManager.speed = initialSpeed;

                UIManager.SetInGameUI ();
            }
        }


        if (gameOver)
        {   
            if (Input.GetKeyDown(KeyCode.DownArrow) || SwipeManager.tap)
            {   
                ColorManager.ClearQueues();
                //reset Game
                SceneManager.LoadScene("Game");
            }
        }
    }

    void StartGame()
    {
        startingGame = true;
    }

    public static void GameOver()
    {   
        UIManager.SetGameOverUI();
        gameOver = true;
        obstManager.speed = 0;

    } 

}
