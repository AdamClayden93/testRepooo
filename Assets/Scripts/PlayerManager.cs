using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Mesh cube, sphere;
    MeshRenderer playerColour;
    MeshFilter playerMesh;
    // 0 = square, 1 = sphere
    public static int playerStates = 0;
    public static int playerMat = 0;
    private void Start()
    {
        playerColour = GetComponent<MeshRenderer>();
        playerMesh = GetComponent<MeshFilter>();
        playerStates = playerMat = 1;
        playerColour.material.color = LerpBackgroundColour.instance.extremeTwo;
        playerMesh.mesh = sphere;
    }

    public void ChangeShape()
    {
        if (playerStates == 0)
        {
            playerMesh.mesh = sphere;
            playerStates = 1;
        }
        else
        {
            playerMesh.mesh = cube;
            playerStates = 0;
        }

        if (PlateManager.tutorialMode)
        {
            UIManager.UIinstance.WakeUpColourButton();
        }
    }

    public void ChangeColour()
    {
        if (playerMat == 0)
        {
            playerColour.material.color = LerpBackgroundColour.instance.extremeTwo;
            playerMat = 1;
        }
        else
        {
            playerColour.material.color = LerpBackgroundColour.instance.extremeOne;
            playerMat = 0;
        }
        if (PlateManager.tutorialMode)
        {
            UIManager.UIinstance.EndTutorial();
        }
    }

    private void Update()
    {
        if (MenuActivator.menuSwitch == 0)
        {
            MenuAI();
        }
    }
    void MenuAI()
    {
        switch (PlateManager.currentPlate)
        {
            case 0:
                playerMesh.mesh = cube;
                playerStates = 0;
                break;
            case 1:
                playerMesh.mesh = sphere;
                playerStates = 1;
                break;
            default:
                break;
        }
        switch (PlateManager.currentMat)
        {
            case 0:
                playerColour.material.color = LerpBackgroundColour.instance.extremeOne;
                playerMat = 0;
                break;
            case 1:
                playerColour.material.color = LerpBackgroundColour.instance.extremeTwo;
                playerMat = 1;
                break;
            default:
                break;
        }
    }
}
