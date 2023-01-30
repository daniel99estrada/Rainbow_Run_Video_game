using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{      
    public static bool gameOver;
    public static bool gameInProgress; 
    public int initialSpeed;

    void Awake()
    {
        obstManager.speed = 0;
        gameOver = false;
        gameInProgress = false; 
    }

    // Start is called before the first frame update
    void Start()
    {
        UIManager.SetStartScreenUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameInProgress)
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
                //reset Game
                SceneManager.LoadScene("Game");
            }
        }
    }

    public static void GameOver()
    {   
        UIManager.SetGameOverUI();

        // GameObject.Find("GameOverUI").GetComponent<GameOverAnimationManager>().playAnimations();

        gameOver = true;
        obstManager.speed = 0;
    } 

}
