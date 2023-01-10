using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleColors : MonoBehaviour
{   
    public static GameObject player;

    public static float[,,] colors = 
    {
        {{38, 70, 83},{42, 157, 143},{233, 196, 106},{244, 162, 97},{231, 111, 81}},
        {{0, 48, 73},{214, 40, 40},{247, 127, 0},{252, 191, 73},{234, 226, 183}},
        {{229, 118, 122},{225, 191, 96},{138, 183, 67},{55, 129, 175},{113, 92, 143}},
        {{230, 57, 70},{241, 250, 238},{168, 218, 220},{69, 123, 157},{29, 53, 87}},
        {{248, 244, 227},{212, 205, 195},{213, 208, 205},{162, 163, 146},{154, 153, 140}}, 
        {{238, 183, 89}, {244, 194, 123}, {231, 155, 97}, {242, 137, 95}, {234, 112, 90}}, 
        {{45, 56, 98}, {152, 165, 221}, {192, 212, 231},{80, 90, 119}, {69, 77, 151}},
        {{181, 49, 62},{193, 51, 73},{157, 63, 72},{106, 27, 36},{82, 20, 35}},
        {{193, 200, 188},{126, 160, 134},{81, 112, 105},{52, 71, 74},{47, 59, 65}},
        {{189, 108, 50}, {193, 133, 87},{210, 154, 75},{216, 178, 101}, {229, 200, 153}},
        {{56, 102, 65},{106, 153, 78},{167, 201, 87},{242, 232, 207},{188, 71, 73}},
        {{125, 115, 121},{155, 144, 157},{157, 153, 173},{177, 179, 211},{195, 203, 224}},
        {{143, 158, 137},{159, 171, 155},{186, 199, 148},{185, 215, 172},{206, 239, 210}},
        {{114, 24, 23},{250, 159, 66},{43, 65, 98},{11, 110, 79},{118, 167, 153}},
        {{231, 207, 213},{218, 180, 184},{215, 162, 194},{176, 140, 169},{126, 104, 124}},
        {{163, 147, 191}, {152, 130, 172}, {115, 100, 138}, {69, 55, 80}, {12, 9, 16}}
    };

    public static List<List<Color>> allPalettes;
    public static Color[] currentPalette;
    public static Color playerColor; 
    public static Queue <Color> colorQueue;
    public static Queue <Color[]> paletteQueue;

    public static int changeColorRate = 3;
    public static int count = 0;
    public static int index = 0; 

    void Awake()
    {   
        // Initialize Variables.
        allPalettes = new List<List<Color>>();
        currentPalette = new Color[5];
        colorQueue = new Queue <Color>();
        paletteQueue = new Queue <Color[]>();

        player = GameObject.Find ("Player");

        SetAllcolorPalettes();

        SetPaletteQueue();

        setPlayerColor();
    }

    public static void SetAllcolorPalettes ()
    {
        for (int i = 0; i < colors.GetLength(0); i++)
        {   
            allPalettes.Add(new List<Color>());

            for (int j = 0; j < colors.GetLength(1); j++)
            {
                allPalettes[i].Add(setRGBtoColor(colors[i, j, 0], colors[i, j, 1], colors[i, j, 2]));
            }
        }
    }

    void SetPaletteQueue ()
    {   
        for (int j = 0; j < 5; j++)
        {
            UpdatePaletteQueue();
        }
    }

    public static void UpdatePaletteQueue ()
    {   
        Color[] palette = new Color[5];

        index = Random.Range(0, allPalettes.Count);
    
        for (int i = 0; i< allPalettes[1].Count; i++)
        {
            palette[i] = allPalettes[index][i];
        }

        playerColor = palette[Random.Range(0, currentPalette.Length)];

        paletteQueue.Enqueue(palette);

        colorQueue.Enqueue(playerColor);
    }

    public static Color setRGBtoColor(float _r, float _g, float _b)
    {
        return new Color(_r/255, _g/255, _b/255);
    }

    public static void setPlayerColor ()
    {   
        Color c = colorQueue.Dequeue();
        
        var playerRenderer = player.GetComponent<Renderer>();

        playerRenderer.material.SetColor("_Color", c);
    }
    
    public static List<int> randomOrder(int totalObstacles, int range)
    {
        List<int> listNumbers = new List<int>();
        int number;

        for (int i = 0; i < totalObstacles; i++)
        {
            do {
                number = Random.Range(0, range);
            } while (listNumbers.Contains(number));
            listNumbers.Add(number);
        }

        return listNumbers;
    }
}

    //   string[] hexColors = new string[] { "a393bf", "9882ac", "73648a", "453750", "0c0910" };
	// 	int[][] rgbValues = new int[hexColors.Length][];

    //   for (int i = 0; i < hexColors.Length; i++)
    //   {
    //       rgbValues[i] = new int[3];
    //       rgbValues[i][0] = Convert.ToInt32(hexColors[i].Substring(0, 2), 16);
    //       rgbValues[i][1] = Convert.ToInt32(hexColors[i].Substring(2, 2), 16);
    //       rgbValues[i][2] = Convert.ToInt32(hexColors[i].Substring(4, 2), 16);
    //   };
    //   string output = "{" + string.Join("}, {", rgbValues.Select(x => string.Join(", ", x))) + "}";
	// 	Console.WriteLine(output);

    // "91ac86","a6bba0","cce18e","d8f4cd","c2ffc8"
    // "f9e0d9","e6dbd0","7d6167","754f5b","5d4954"
    // ["7a918d","93b1a7","99c2a2","c5edac","dbfeb8"]
    // ["d1b1c8","b1b7d1","9b9fb5","8c7284","7a6174"]