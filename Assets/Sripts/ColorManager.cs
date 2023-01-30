using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{   
    public static GameObject player;

    public static float[,,] colors = 
    {
        {{0, 48, 73},{214, 40, 40},{247, 127, 0},{252, 191, 73},{234, 226, 183}}, //easy
        {{229, 118, 122},{225, 191, 96},{138, 183, 67},{55, 129, 175},{113, 92, 143}}, //easy
        {{230, 57, 70},{241, 250, 238},{168, 218, 220},{69, 123, 157},{29, 53, 87}}, //easy
        {{56, 102, 65},{106, 153, 78},{167, 201, 87},{242, 232, 207},{188, 71, 73}}, //easy
        {{96,108,56}, {40,54,24}, {254,250,224}, {221,161,94}, {188,108,37}},
        {{120,0,0}, {193,18,31}, {253,240,213}, {0,48,73}, {102,155,188}},
        {{43,45,66}, {124,138,162}, {237,242,244}, {239,46,69}, {253,114,137}},
        {{40,61,59}, {25,114,120}, {237,221,212}, {196,69,54}, {119,46,37}},
        {{12,55,96}, {120,140,143}, {247,232,170}, {242,204,68}, {238,147,68}},
        {{151,66,33}, {127,176,105}, {236,228,183}, {233,199,144}, {52,31,9}},
        {{143, 158, 137},{159, 171, 155},{186, 199, 148},{185, 215, 172},{206, 239, 210}}, //easy
        {{229,193,189}, {210,208,186}, {182,190,156}, {123,158,135}, {94,116,127}},
        {{202,207,133}, {171,197,131}, {140,186,128}, {101,142,156}, {77,83,130}},
        {{0,20,39}, {112,141,129}, {178,177,135}, {244,213,141}, {201,6,3}},
        {{45, 56, 98}, {152, 165, 221}, {192, 212, 231},{80, 90, 119}, {69, 77, 151}}, //medium hard
        {{105,109,125}, {111,146,131}, {141,159,135}, {205,198,165}, {240,220,202}},
        {{13,59,102}, {132,150,152}, {250,240,202}, {244,211,94}, {241,181,85}},
        {{61,90,128}, {152,193,217}, {224,251,252}, {238,108,77}, {41,50,65}},
        {{96,67,85}, {164,86,94}, {213,226,246}, {254,246,241}, {225,186,152}},
        {{36,62,54}, {124,169,130}, {224,238,198}, {209,203,130}, {194,168,62}},
        {{20,11,50}, {54,38,167}, {101,126,212}, {216,120,133}, {235,235,255}},
        {{61,90,128}, {152,193,217}, {224,251,252}, {238,108,77}, {41,50,65}},
        {{205,195,146}, {232,229,218}, {158,183,229}, {100,141,229}, {48,76,137}},
        {{184,198,204}, {200,206,161}, {208,211,143}, {169,175,110}, {139,148,97}}, //mh
        {{175,192,213}, {224,255,214}, {199,230,137}, {192,212,97}, {113,128,35}}, //mh
        {{193, 200, 188},{126, 160, 134},{81, 112, 105},{52, 71, 74},{47, 59, 65}}, //hard
        {{73,71,91}, {121,148,150}, {172,193,150}, {203,214,154}, {233,235,158}},
        {{19,42,19}, {49,87,44}, {79,119,45}, {144,169,85}, {236,243,158}},
        {{3,63,99}, {124,152,133}, {181,182,130}, {218,201,141}, {254,220,151}},
        {{189, 108, 50}, {193, 133, 87},{210, 154, 75},{216, 178, 101}, {229, 200, 153}}, //hard
        {{227,215,255}, {175,176,225}, {122,137,194}, {95,107,149}, {114,120,141}}, //hard
        {{114, 24, 23},{250, 159, 66},{43, 65, 98},{11, 110, 79},{118, 167, 153}}, //hard
        {{255,214,255}, {231,198,255}, {200,182,255}, {184,192,255}, {187,208,255}},
        {{255,205,178}, {255,180,162}, {229,152,155}, {181,131,141}, {109,104,117}},
        {{163, 147, 191}, {152, 130, 172}, {115, 100, 138}, {69, 55, 80}, {12, 9, 16}},
        {{208,219,151}, {157,200,136}, {105,181,120}, {58,125,68}, {37,77,50}}
    };

    public static List<List<Color>> allPalettes;
    public static Color[] currentPalette;
    public static Color playerColor; 
    public static Queue <Color> colorQueue;
    public static Queue <Color[]> paletteQueue;

    // Variables to Pick a Random Palette.
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
            List<Color> palette = new List<Color>();

            allPalettes.Add(palette);

            for (int j = 0; j < colors.GetLength(1); j++)
            {   
                Color color = setRGBtoColor(colors[i, j, 0], colors[i, j, 1], colors[i, j, 2]);

                allPalettes[i].Add(color);
            }
        }
    }

    void SetPaletteQueue ()
    {   
        for (int j = 0; j < 20; j++)
        {
            UpdatePaletteQueue();
        }
    }

    public static void UpdatePaletteQueue ()
    {   
        index = PickAPalette();

        Color[] palette = new Color[5];

        for (int i = 0; i < allPalettes[1].Count; i++)
        {
            palette[i] = allPalettes[index][i];
        }

        playerColor = palette[Random.Range(0, currentPalette.Length)];

        paletteQueue.Enqueue(palette);

        colorQueue.Enqueue(playerColor);
    }

    public static int PickAPalette()
    {

        index = count % allPalettes.Count;

        count += Random.Range(1, 3);;

        return index;
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