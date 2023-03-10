using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{   
    public static float score;
    public float increment;
    TextMeshProUGUI textmeshPro;

    void Start()
    {   
        score = 0;
        textmeshPro = GetComponent<TextMeshProUGUI>();
    }

    public void Update()
    {    
        if (GameManager.gameOver) return;
        
        score += increment * Time.deltaTime;
        textmeshPro.SetText(score.ToString("0"));
    }
}
