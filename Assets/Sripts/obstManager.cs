using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstManager : MonoBehaviour
{   
    public static float speed;

    public int startZ = 100;
    public int divisions = 5;

    public static int totalPassed;

    public GameObject rainbowBlock;

    // Prefab for the obstacle
    public GameObject obstaclePrefab;

    public float spawnInterval;

    // Speed at which the obstacles move
    public float obstacleSpeed = 16.0f;

    // Speed increase rate per second
    public float speedIncreaseRate;

    // Initial spawn delay
    public float initialDelay = 0.5f;

    public int distanceBetweenBlock = 100;

    public Queue <obst> obstacleQueue = new Queue <obst>();

    void Awake()
    {   
        for (int j = 0; j < 3; j++)
        {
            instantiateBlocks();
            startZ += distanceBetweenBlock;
        }

        startZ -= distanceBetweenBlock;
    }

    void Start()
    {   
        totalPassed = 0;

        // Increase the obstacle speed gradually over time
        InvokeRepeating("IncreaseObstacleSpeed", initialDelay, spawnInterval);
    }

    void SpawnObstacle()
    {
        // Instantiate the obstacle at the spawner position
        GameObject obstacle = Instantiate(obstaclePrefab, transform.position, Quaternion.identity);

        // Set the obstacle's speed
        obstacle.GetComponent<obst>().speed = obstacleSpeed;
    }

    void IncreaseObstacleSpeed()
    {
        // Increase the obstacle speed by the specified rate
        obstacleSpeed += speedIncreaseRate;      
    }
    
    public void instantiateBlocks()
    {
        GameObject o = Instantiate(rainbowBlock, new Vector3(0, 0f, startZ), Quaternion.identity);

        GameObject coinManager = GameObject.Find("CoinManager");
        CoinManager CoinManager = coinManager.GetComponent<CoinManager>();

        CoinManager.InstantiateCoins();
         
        o.GetComponent<obst>().speed = obstacleSpeed;

        //Remove color to PalletteQueue
        ObstacleColors.paletteQueue.Dequeue();

        //Add a new color to PalletteQueue
        ObstacleColors.UpdatePaletteQueue();
    }
}
 