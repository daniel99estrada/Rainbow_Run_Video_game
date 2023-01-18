using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverAnimationManager : MonoBehaviour
{   
    Animations GameOverTitle;
    Animations ScorePanel;

    void Start()
    {   
        GameOverTitle = GameObject.Find("GameOverTitle").GetComponent<Animations>();
        ScorePanel = GameObject.Find("FinalScorePanel").GetComponent<Animations>();
    }

    public void playAnimations()
    {   
        GameOverTitle.PlayAnimation("A_GameOverTitle");
        ScorePanel.PlayAnimation("FinalScorePanel");
    }
}
