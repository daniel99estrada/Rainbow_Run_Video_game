using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{   
    public GameObject coinPrefab;
    public GameObject coinUIPrefab;
    public GameObject megaCoin;
    public int minCoins;
    public int maxCoins;
    public float height;
    public float offset;

    private int laneWidth;
    public int totalLanes;
    private int currentLane;
    private int totalCoins;

    private float startZ;

    private obstManager obstacleManager;
    private GameObject obstacle;

    public LinkedList<GameObject> coinLinkedList = new LinkedList<GameObject>();
    public GameObject LastCollectedCoin;
    public GameObject lastCoinOnStreak;
    public GameObject head;
    bool reset = true;

    public int coinScore;
    int[] coinScores = {1, 3, 5, 11, 15, 25, 50, 100, 300, 500, 1000, 2000, 3000, 4000};
    public static int streakCount;

    void Awake ()
    {   
        streakCount = 0;
        laneWidth = Ground.width;
        coinLinkedList.Clear();

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

    public void DisplayText(GameObject coin)
    {   
        CheckForStreak(coin);
        SetValue();
        Instantiate(coinUIPrefab, new Vector3(0f,0f,0f), Quaternion.identity);
    }

    public void CheckForStreak(GameObject coin)
    {   
        if (LastCollectedCoin.GetInstanceID() == getPreviousCoin(coin).GetInstanceID() && !reset)
        {   
            streakCount += 1;
        }
        else
        {
            streakCount = 0;
        }
        LastCollectedCoin = coin;
        reset = false;
    }

    public void ResetStreak()
    {
        streakCount = 0;
        reset = true;
    }

    public void SetValue()
    {   
        coinScore = coinScores[streakCount];
        ScoreUI.score += coinScore;
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

   
