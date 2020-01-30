using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class UIManager : MonoBehaviour
{
    public static UIManager UIinstance;
    Animator uiAnimations;
    public TextMeshProUGUI scoreText;
    public int scoreNum = 0;
    public GameObject shapeTut, colTut;
    public Button shapeChange, colChange;
    public TextMeshProUGUI game, over;
    public static bool startAnimation = false;
    bool highscoreOnce;
    WaitForSeconds oneSec = new WaitForSeconds(1.0f);
    WaitForSeconds onePointThree = new WaitForSeconds(1.3f);

    private void Awake()
    {
        UIinstance = this;
    }

    // Use this for initialization
    void Start ()
    {
        highscoreOnce = true;
        uiAnimations = GetComponent<Animator>();
        if (!PlateManager.tutorialMode)
        {
            EndTutorial();
        }
    }

    public void WakeUpShapeButton()
    {
        shapeTut.SetActive(true);
        shapeChange.interactable = true;
    }
    
    public void WakeUpColourButton()
    {
        shapeTut.SetActive(false);
        shapeChange.interactable = false;
        colTut.SetActive(true);
        colChange.interactable = true;
    }

    public void EndTutorial()
    {
        PlateManager.tutorialMode = false;
        colTut.SetActive(false);
        shapeTut.SetActive(false);
        shapeChange.interactable = true;
        colChange.interactable = true;
    }

    public void AdjustScore()
    {
        if (MenuActivator.menuSwitch == 1)
        {
            scoreNum += 1;
            if(scoreNum > HighScore.highscore)
            {
                HighScore.highscore = scoreNum;
                if (highscoreOnce)
                {
                    uiAnimations.SetTrigger("HighscoreAnim");
                    highscoreOnce = false;
                }
            }
            scoreText.text = scoreNum.ToString();
            startAnimation = true;
            uiAnimations.SetTrigger("increaseScore"); //-44.5 original centre value
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    IEnumerator PrintGameover()
    {
        game.enabled = true;
        yield return oneSec;
        over.enabled = true;
        yield return onePointThree;
        SceneManager.LoadScene(0);
    }
}
