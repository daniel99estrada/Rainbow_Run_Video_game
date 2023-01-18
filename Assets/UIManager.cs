using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static Canvas GameOverUI;
    public static Canvas StartUI;
    public static Canvas ScoreUI;

    void Awake()
    {
        StartUI = GameObject.Find("StartUI").GetComponent<Canvas>();
        GameOverUI = GameObject.Find("GameOverUI").GetComponent<Canvas>();
        ScoreUI = GameObject.Find("ScoreUI").GetComponent<Canvas>();

    }

    public static void SetStartScreenUI()
    {
        StartUI.enabled = true;
        ScoreUI.enabled = false;
        GameOverUI.enabled = false;
    }

    public static void SetInGameUI ()
    {
        StartUI.enabled = false;
        ScoreUI.enabled = true;
    }

    public static void SetGameOverUI()
    {
        GameOverUI.enabled = true;
        ScoreUI.enabled = false;
    }
}
