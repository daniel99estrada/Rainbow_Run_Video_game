using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstManager : MonoBehaviour
{   

    public static float initialSpeed = 18;

    public int startZ = 100;
    public int divisions = 5;

    public static int totalPassed;

    public GameObject rainbowBlock;

    // Prefab for the obstacle
    public GameObject obstaclePrefab;

    public float speedIncreaseInterval;

    // Speed increase rate per second
    public float speedIncreaseRate;

    // Initial spawn delay
    public float initialDelay = 0.5f;

    public int distanceBetweenBlock = 100;

    public static float speed;

    public Queue <obst> obstacleQueue = new Queue <obst>();

    GameObject coinManager;
    CoinManager CoinManager;

    void Awake()
    {   
        coinManager = GameObject.Find("CoinManager");
        CoinManager = coinManager.GetComponent<CoinManager>();

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
        InvokeRepeating("IncreaseObstacleSpeed", initialDelay, speedIncreaseInterval);
    }

    void IncreaseObstacleSpeed()
    {
        // Increase the obstacle speed by the specified rate
        speed += speedIncreaseRate;      
    }
    
    public void instantiateBlocks()
    {
        Instantiate(rainbowBlock, new Vector3(0, 0f, startZ), Quaternion.identity);

        CoinManager.InstantiateCoins();

        //Remove color pallette from PalletteQueue
        ObstacleColors.paletteQueue.Dequeue();

        //Add a new color to PalletteQueue
        ObstacleColors.UpdatePaletteQueue();
    }
}
 