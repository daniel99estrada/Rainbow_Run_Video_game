using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        GameObject.Find("StartUI").SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {   
            Time.timeScale = 1;
            GameObject.Find("StartUI").SetActive(false);
        }
    }
}
