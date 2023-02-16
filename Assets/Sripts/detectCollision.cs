using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public Renderer playerRenderer;
    public float jumpDuration = 0.4f;
    public CoinManager coinManagerScript;

    public GameObject detroyEffect;

    private void Awake()
    {
        coinManagerScript = GameObject.Find("CoinManager").GetComponent<CoinManager>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        Renderer collisionRenderer = collision.gameObject.GetComponent<Renderer>();

        if (collision.gameObject.CompareTag("Coin"))
        {
            HandleCoinCollision(collision, collisionRenderer);
            return;
        }
        else if (collisionRenderer.material.color != playerRenderer.material.color)
        {   
            DestroyPlayer();
            GameManager.GameOver();
        }
        else
        {
            HandleObstacleCollision(collision, collisionRenderer);
        }
    }

    private void HandleCoinCollision(Collider coin, Renderer coinRenderer)
    {
        Destroy(coin.gameObject);
        SoundEffects.playSoundEffect();
        playerRenderer.material.SetColor("_Color", coinRenderer.material.color);
        Jump(2);
        coinManagerScript.DisplayText(coin.gameObject);
    }

    private void HandleObstacleCollision(Collider obstacle, Renderer obstacleRenderer)
    {
        obstacle.gameObject.transform.parent.gameObject.GetComponent<obst>().DestroyEffect();
        SoundEffects.playSoundEffect();
        Jump(5);
        ColorManager.setPlayerColor();
        coinManagerScript.ResetStreak();
    }

    private void Jump(float jumpForce)
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        Invoke("StopJump", jumpDuration);
    }

    private void StopJump()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    private void DestroyPlayer()
    {   
        // Destroy(this.gameObject);

        Vector3 position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z + 2);
        Jump(6);

        //Instantiate Destroy effect
        GameObject effect = Instantiate(detroyEffect, transform.position, Quaternion.identity);

        //Change the Color of the effect to that of the obstacle
        effect.GetComponent<Renderer>().material.color = GetComponent<Renderer>().material.GetColor("_Color");       
    }
}
