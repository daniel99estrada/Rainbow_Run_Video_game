using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obst : MonoBehaviour
{   
    // Public variables that can be set in the Unity editor
    public GameObject player;
    public GameObject ground;
    public GameObject prefab;
    public GameObject destroyEffect;
    public float speed;
    public float effectPositionY;
    public float freezeDistance;

    private float divisions;
    private int startZ;
    private obstManager obstacleManager;
    private GameObject obstacle;
    private Player playerScript;
    private int WIDTH;



    bool canBuild = true;

    void Awake()
    {   
        obstacle = GameObject.Find("ObstacleManager");
        obstacleManager = obstacle.GetComponent<obstManager>();

        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();


        divisions = obstacleManager.divisions;
        startZ = obstacleManager.startZ;
        WIDTH = Ground.width;

        instantiate();
        
        obstacleManager.obstacleQueue.Enqueue(this);
    }

    void Update()
    {
        move();
        delete();
        freezePlayer();

        if (transform.position.z <= 0 && canBuild) 
        {
            obstacleManager.instantiateBlocks();
            canBuild = false;
        }
    }

    public void instantiate()
    {   

        Color[] colorPalette = ColorManager.paletteQueue.Peek();

        List<int> index = new List<int>(ColorManager.randomOrder(5, 5));

        for (var j = 0; j < divisions; j++)
        {   
            Vector3 position;
            GameObject obst;

            //Set the position.
            float x = WIDTH/divisions * j + (WIDTH/divisions)/2 - WIDTH/2;

            for (int i = 0; i < 2; i++)
            {
                if (i == 0)
                {
                    position = new Vector3(x, prefab.transform.localScale.y/2, startZ);
                    obst = Instantiate(prefab, position, Quaternion.identity);
                    obst.transform.localScale = new Vector3(WIDTH/divisions, prefab.transform.localScale.y, prefab.transform.localScale.z);
                }
                else
                {
                    position = new Vector3(x, -0.5f, startZ - obstacleManager.distanceBetweenBlock/2 );
                    obst = Instantiate(prefab, position, Quaternion.identity);
                    obst.transform.localScale = new Vector3(WIDTH/divisions, prefab.transform.localScale.z, obstacleManager.distanceBetweenBlock);
                    obst.GetComponent<Collider>().enabled = false;
                    obst.tag = "Ground";
                } 

                //Assign a color.
                var cubeRenderer = obst.GetComponent<Renderer>();
                cubeRenderer.material.SetColor("_Color", colorPalette[index[j]]);
                
                // //Set parent.
                obst.transform.parent = this.transform;
            }
        }   
    }

    public void move()
    {   
        if (GameManager.gameOver || !GameManager.gameInProgress) return;

        speed = obstManager.speed;

        this.transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
    }
    
    void delete()
    {   
        if (this.transform.position.z < player.transform.position.z)
        {   
            Destroy(this.gameObject, (2.0f));
        }
    }

    void freezePlayer()
    {
        if (obstacleManager.obstacleQueue.Peek() == this)
        {
            float dist = Vector3.Distance(transform.position, player.transform.position);

            if (dist < freezeDistance)
            {   
                playerScript.canMove = false;
            }
            else
            {
                playerScript.canMove = true;
            }
        }
    }

    public void DestroyEffect()
    {
        for (int i=0; i< transform.childCount; i++)
        {   
            GameObject child = transform.GetChild(i).gameObject;

            Vector3 position  = new Vector3(child.transform.position.x, effectPositionY, child.transform.position.z);

            //Instantiate Destrou effect
            GameObject effect = Instantiate(destroyEffect, position, Quaternion.identity);

            //Change the Color of the effect to that of the obstacle
            effect.GetComponent<Renderer>().material.color = child.GetComponent<Renderer>().material.GetColor("_Color");

            Destroy(effect, 5f);

            if (child.tag != "Ground")
            {
                Destroy(child);
            }
        }
        obstacleManager.obstacleQueue.Dequeue();
    }
}
