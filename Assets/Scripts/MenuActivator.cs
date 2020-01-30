using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuActivator : MonoBehaviour
{
    [SerializeField] Animator titleAnimation;
    public static int menuSwitch;
    private void Start()
    {
        menuSwitch = SceneManager.GetActiveScene().buildIndex;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    private void Update()
    {
        if(!Globals.skipSequence && Input.GetMouseButtonUp(0))
        {
            Globals.skipSequence = true;
            titleAnimation.Play("TitleOpening", 0, 1);
        }
    }
}
