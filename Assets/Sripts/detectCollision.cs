using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class detectCollision : MonoBehaviour
{   
    public Renderer playerRenderer;
    // float jumpForce = 0.4f;
    public float jumpDuration = 0.4f;

    public GameObject CoinManager;
    public CoinManager CoinManagerScript;

    void Awake ()
    {
        CoinManager = GameObject.Find("CoinManager");
        CoinManagerScript = CoinManager.GetComponent<CoinManager>();
    }

    void OnTriggerEnter(Collider collision)
    {   

        Renderer collisionRenderer = collision.gameObject.GetComponent<Renderer>();
        
        # region Coin Collision
        if (collision.gameObject.tag == "Coin")
        {      
            //Destroy coin.
            Destroy(collision.gameObject);

            //Play sound effect
            SoundEffects.playSoundEffect();

            //Set the Player's color to that of the coin.
            playerRenderer.material.SetColor("_Color", collisionRenderer.material.color);

            //Make the player jump.
            Jump(2);

            CoinManagerScript.checkForStreak(collision.gameObject);

            CoinManagerScript.DisplayText();

            return;
        }
        #endregion

        //Check if the right obstacle was traversed.
        if (collisionRenderer.material.color != playerRenderer.material.color)
        {
            GameManager.GameOver();
        }

        //Destroy Obstacles
        collision.gameObject.transform.parent.gameObject.GetComponent<obst>().DestroyEffect();

        //Play a sound effect
        SoundEffects.playSoundEffect();

        //Jump Effect
        Jump(5);

        //Set the player's color.
        ObstacleColors.setPlayerColor();

        CoinManagerScript.streakCount = 0;
    }

    void Jump(float jumpForce)
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        Invoke("StopJump", jumpDuration);
    }

    void StopJump()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}



