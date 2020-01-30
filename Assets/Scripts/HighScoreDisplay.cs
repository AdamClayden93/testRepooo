using UnityEngine;
using TMPro;

public class HighScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI highscore;
    public TextMeshProUGUI hsText;
    // Use this for initialization
    private void Awake()
    {
        hsText.text = "0";
    }
    void Start ()
    {
        hsText.text = HighScore.highscore.ToString();
	}
}
