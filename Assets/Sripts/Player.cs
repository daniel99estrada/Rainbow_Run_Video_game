using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    // Public variables that can be set in the Unity editor
    public float speed; // Speed at which the player moves between lanes
    public float laneOffset; // Offset of the lanes from the center of the screen
    public LayerMask triggerLayer; // Layer mask for the trigger objects

    // Private variables
    private int numLanes; // Number of lanes in the game
    private float laneWidth; // Width of each lane
    public bool canMove; // Flag to track whether the player can move or not
    private int currentLane; // Index of the current lane the player is in
    private float targetXPos; // Target x position for the player to move to
    private Rigidbody rb; // Reference to the player's Rigidbody component
    
    void Start()
    {
        // Initialize variables
        numLanes = 5;
        laneWidth = Ground.width / numLanes;
        canMove = true;
        currentLane = numLanes / 2; // Start in the middle lane
        targetXPos = CalculateLaneXPos(currentLane);
        rb = GetComponent<Rigidbody>();

        GameObject text = new GameObject();
        TextMeshPro t = text.AddComponent<TextMeshPro>();
        t.text = "10";
        t.fontSize = 5;
        t.transform.localPosition += new Vector3(-0f, 1f, 0f);

    }

    void Update()
    {
        // Check if the player is allowed to move
        if (canMove)
        {
            // Check for input to move left or right
            if (Input.GetKeyDown(KeyCode.LeftArrow) && currentLane > 0)
            {
                currentLane--;
                targetXPos = CalculateLaneXPos(currentLane);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && currentLane < numLanes - 1)
            {
                currentLane++;
                targetXPos = CalculateLaneXPos(currentLane);
            }
        }

        // Gradually move the player towards the target x position
        rb.position = Vector3.MoveTowards(rb.position, new Vector3(targetXPos, rb.position.y, rb.position.z), speed * Time.deltaTime);
    }


    // Calculates the x position of a lane based on its index
    float CalculateLaneXPos(int laneIndex)
    {
        return laneOffset + laneWidth * laneIndex - laneWidth * (numLanes - 1) / 2;
    }
}
