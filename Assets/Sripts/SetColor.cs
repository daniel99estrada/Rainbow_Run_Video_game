using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColor : MonoBehaviour
{   
    public obstManager obstacleManager;
    public GameObject obstacle;
    private float speed;

    void Start()
    {
        obstacle = GameObject.Find("ObstacleManager");
        obstacleManager = obstacle.GetComponent<obstManager>();
    }
    void Update()
    {
        move();
    }

    void move ()
    {   
        speed = obstacleManager.speed;

        this.transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
    }
}
