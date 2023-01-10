using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinText : MonoBehaviour
{   
    public float textDuration;
    public float y;
    public float z;
    
    GameObject player;
    TextMeshPro textMeshPro;
    GameObject CoinManager;
    CoinManager CoinManagerScript;

    void Awake ()
    {
        CoinManager = GameObject.Find("CoinManager");
        CoinManagerScript = CoinManager.GetComponent<CoinManager>();

        player = GameObject.Find("Player");

        textMeshPro = gameObject.GetComponent<TextMeshPro>();

        ShowText();
    }

    public void ShowText()
    {   
        transform.position = new Vector3(player.transform.position.x, y, z);

        textMeshPro.text = "+" + CoinManagerScript.coinScore.ToString();

        Invoke("ClearText", textDuration);
    }

    public void ClearText()
    {
        textMeshPro.text = "";
    }
}
