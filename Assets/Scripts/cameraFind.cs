using UnityEngine;
using UnityEngine.Video;

public class cameraFind : MonoBehaviour
{
    Camera levelCam;
    bool targetCam = false;
    static bool first = true;

    private void Awake()
    {
        if(first)
        {
            DontDestroyOnLoad(this.gameObject);
            first = false;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        levelCam = Camera.main;
        GetComponent<VideoPlayer>().targetCamera = levelCam;
    }
}