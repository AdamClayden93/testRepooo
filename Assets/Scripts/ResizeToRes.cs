using UnityEngine;
using UnityEngine.UI;
public class ResizeToRes : MonoBehaviour
{
    Vector2 landscapeMode, portraitMode;
    RectTransform thisRectT;

    void Awake()
    {
        thisRectT = GetComponent<RectTransform>();
    }
	// Use this for initialization
	void Start ()
    {
        landscapeMode = new Vector2(Screen.width / 2, Screen.height);
        portraitMode = new Vector2(Screen.width, Screen.height / 2);
		if(Screen.width > Screen.height)
        {
            thisRectT.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width/2);
            thisRectT.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height);
        }
        else
        {
            thisRectT.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width);
            thisRectT.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height/2);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Screen.width > Screen.height)
        {
            thisRectT.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width / 2);
            thisRectT.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height);
        }
        else
        {
            thisRectT.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width);
            thisRectT.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / 2);
        }
    }
}
