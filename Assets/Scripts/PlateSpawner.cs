using UnityEngine;

public class PlateSpawner : MonoBehaviour
{
    public Transform startPos, endPos, tutorialPos;
    public static PlateSpawner pspwnInstance;

    private void Awake()
    {
        pspwnInstance = this;
    }
}