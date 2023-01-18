using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScore : MonoBehaviour
{   
    TextMeshProUGUI textmeshPro;

    void Start()
    {   
        textmeshPro = GetComponent<TextMeshProUGUI>();
    }

    public void Update()
    {    
        textmeshPro.SetText(ScoreUI.score.ToString("0"));
    }
}
