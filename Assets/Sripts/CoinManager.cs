using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{   
    public GameObject coinPrefab;
    public GameObject coinUIPrefab;
    public int minCoins;
    public int maxCoins;
    private Vector3 position;
    public float height;
    public float offset;

    private int laneWidth;
    public int totalLanes;
    private int currentLane;
    private int totalCoins;

    private float startZ;

    private obstManager obstacleManager;
    private GameObject obstacle;

    public int coinScore;
    public int scoreIncrement;

    public LinkedList<GameObject> coinLinkedList = new LinkedList<GameObject>();
    public GameObject LastCollectedCoin;
    public GameObject lastCoinOnStreak;
    public GameObject head;

    void Awake ()
    {   
        laneWidth = Ground.width;

        obstacle = GameObject.Find("ObstacleManager");
        obstacleManager = obstacle.GetComponent<obstManager>();
    }

    public void InstantiateCoins()
    {   
        startZ = obstacleManager.startZ;

        //Set amount of coins.
        totalCoins = Random.Range(minCoins, maxCoins);

        for (int i = totalCoins; i > 1; i--)
        {   
            //Set the X position.
            currentLane = Random.Range(0, totalLanes);
            float x = laneWidth/totalLanes * currentLane + (laneWidth/totalLanes)/2 - laneWidth/2;
 
            //Set the Z position.
            float z = startZ - ((obstacleManager.distanceBetweenBlock/totalCoins) * i) + offset;

            //Set the position.
            Vector3 position = new Vector3(x, height, z);

            //Instantiate coin.
            GameObject coin = Instantiate(coinPrefab, position, Quaternion.identity);

            addToCoinLinkedList(coin);
        }
    }

    public void DisplayText()
    {   
        Instantiate(coinUIPrefab, new Vector3(0f,0f,0f), Quaternion.identity);
    }

    public void checkForStreak(GameObject Coin)
    {   
        if (LastCollectedCoin.GetInstanceID() == getPreviousCoin(Coin).GetInstanceID())
        {   
            coinScore += Random.Range(1,7);
        }
        else
        {
            coinScore = 1;
        }

        ScoreUI.score += coinScore;

        LastCollectedCoin = Coin;
    }

    public void addToCoinLinkedList(GameObject coin)
    {
        if (head == null)
        {
            head = coin;
        }
        else
        {   
            coin.GetComponent<Coin>().previous = head;
            head = coin;
        }
    }

    GameObject getPreviousCoin(GameObject Coin)
    {
        Coin coin = Coin.GetComponent<Coin>();
        return coin.previous;
    }
}
