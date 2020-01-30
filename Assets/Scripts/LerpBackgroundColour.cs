using System.Collections;
using UnityEngine;

public class LerpBackgroundColour : MonoBehaviour
{
    public static LerpBackgroundColour instance;
    public Color extremeOne, extremeTwo, bgOne, bgTwo, bgThree;
    const int LENGTH = 3;
    Color[] colourArray = new Color[LENGTH];// { bgOne, Color.yellow, Color.cyan, Color.magenta };
                                            // Use this for initialization

    private void Awake()
    {
        instance = this;
    }

    void Start ()
    {
        InitialiseColours();
        StartCoroutine(LerpColours());
	}

    void InitialiseColours()
    {
        colourArray[0] = bgOne;
        colourArray[1] = bgTwo;
        colourArray[2] = bgThree;
    }

    IEnumerator LerpColours()
    {
        float delayTime = 13.0f;
        Color currentcolour = colourArray[Random.Range(0, LENGTH)];
        Color nextcolour;

        while (true)
        {
            nextcolour = colourArray[Random.Range(0, LENGTH)];

            for (float t = 0; t < delayTime; t += Time.deltaTime)
            {
                GetComponent<Camera>().backgroundColor = Color.Lerp(currentcolour, nextcolour, t / delayTime);
                yield return null;
            }
            currentcolour = nextcolour;
        }
    }
}
