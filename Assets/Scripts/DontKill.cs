using UnityEngine;

public class DontKill : MonoBehaviour
{
    static bool firstTimeLoaded = true;

    private void Awake()
    {
        if(firstTimeLoaded)
        {
            DontDestroyOnLoad(this.gameObject);
            firstTimeLoaded = false;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
