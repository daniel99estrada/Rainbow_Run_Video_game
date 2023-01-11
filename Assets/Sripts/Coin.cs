using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{   
    private obstManager obstacleManager;
    private GameObject obstacle; 
    GameObject player;
    private float speed;

    public GameObject previous; 
    
    void Awake()
    {
        //Assign a color.
        var coinRenderer = GetComponent<Renderer>();
        coinRenderer.material.SetColor("_Color", ObstacleColors.paletteQueue.Peek()[Random.Range(0,5)]);
    }

    // Start is called before the first frame update
    void Start()
    {
        obstacle = GameObject.Find("ObstacleManager");
        obstacleManager = obstacle.GetComponent<obstManager>();

        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        move();
        delete();
    }

    public void move ()
    {   
        speed = obstManager.speed;

        this.transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
    }

    void delete()
    {   
        if (this.transform.position.z < player.transform.position.z)
        {   
            speed = speed * 1.1f;
            Destroy(this.gameObject, (2.0f));
        }
    }
}
