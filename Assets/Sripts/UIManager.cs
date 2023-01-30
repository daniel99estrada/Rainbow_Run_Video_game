using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static CanvasAnimation GameOverPanel;
    public static CanvasAnimation FinalScorePanel;
    public static TextAnimator GameOverTapToPlay;

    // public static Canvas GameOverUI;
    public static Canvas StartUI;
    public static Canvas ScoreUI;

    void Awake()
    {
        StartUI = GameObject.Find("StartUI").GetComponent<Canvas>();

        // GameOverUI = GameObject.Find("GameOverUI").GetComponent<Canvas>();

        GameOverPanel = GameObject.Find("GameOverPanel").GetComponent<CanvasAnimation>();
        FinalScorePanel = GameObject.Find("FinalScorePanel").GetComponent<CanvasAnimation>();
        GameOverTapToPlay = GameObject.Find("GameOverTapToPlay").GetComponent<TextAnimator>();

        ScoreUI = GameObject.Find("ScoreUI").GetComponent<Canvas>();

    }

    public static void SetStartScreenUI()
    {
        StartUI.enabled = true;
        ScoreUI.enabled = false;
    }

    public static void SetInGameUI ()
    {
        StartUI.enabled = false;
        ScoreUI.enabled = true;
    }

    public static void SetGameOverUI()
    {
        ScoreUI.enabled = false;
        GameOverTapToPlay.anim_enabled = true;
        GameOverPanel.anim_enabled = true;
        FinalScorePanel.anim_enabled = true;
    }
}
