using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   
    bool gameOver = false;
    bool startingGame = true; 

    // Start is called before the first frame update
    void Start()
    {
        // Time.timeScale = 0;
        obstManager.speed = 0;
        GameObject.Find("StartUI").SetActive(true);
        GameObject.Find("ScoreUI").SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) && startingGame)
        {   
            // Time.timeScale = 1;
            obstManager.speed = 18;
            GameObject.Find("StartUI").SetActive(false);
            GameObject.Find("ScoreUI").SetActive(true);
            startingGame = false;
        }
    }
}
