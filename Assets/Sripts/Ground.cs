using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{   
    public Transform ground1;
    public Transform ground2;

    public static int width = 10;
    public static int length = 200;
    public Vector3 scale;

    void Awake()
    {   
        scale = new Vector3 (width, ground1.localScale.y, length);
        ground1.localScale = scale;
        ground2.localScale = scale;
    }
}
