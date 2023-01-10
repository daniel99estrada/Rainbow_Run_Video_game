using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{   
    public static float score;
    TextMeshProUGUI textmeshPro;

    void Start()
    {   
        score = 0;
        textmeshPro = GetComponent<TextMeshProUGUI>();
    }

    public void Update()
    {      
        score += 10 * Time.deltaTime;
        textmeshPro.SetText(score.ToString("0"));
    }
}
