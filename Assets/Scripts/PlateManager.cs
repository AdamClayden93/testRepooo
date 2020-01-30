using UnityEngine;

public partial class PlateManager : MonoBehaviour
{
    public static bool tutorialMode = true;
    bool tempCheck;
    MeshRenderer plateMeshRend;
    MeshFilter thePlateMF;
    public static int currentPlate = 0, currentMat = 0;
    public Mesh altPlate, squarePlate;
    [SerializeField] float speed;
    public int menuSwitch;
    private void Start()
    {
        if(tutorialMode)
        {
            tempCheck = true;
        }
        transform.position = PlateSpawner.pspwnInstance.startPos.position;
        thePlateMF = GetComponent<MeshFilter>();
        plateMeshRend = GetComponent<MeshRenderer>();
        currentPlate = currentMat = 0;
        plateMeshRend.material.color = LerpBackgroundColour.instance.extremeOne;
        thePlateMF.mesh = squarePlate;
    }
    // Update is called once per frame
    void Update()
    {
        if (!tutorialMode)
        {
            transform.position = Vector3.MoveTowards(transform.position, PlateSpawner.pspwnInstance.endPos.position, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, PlateSpawner.pspwnInstance.endPos.position) < .01f)
            {
                ChangePlate();
                transform.position = PlateSpawner.pspwnInstance.startPos.position;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, PlateSpawner.pspwnInstance.tutorialPos.position, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, PlateSpawner.pspwnInstance.tutorialPos.position) < .01f)
            {
                if (MenuActivator.menuSwitch == 0)
                {
                    ChangePlate();
                    transform.position = PlateSpawner.pspwnInstance.startPos.position;
                }
                else
                {
                    if (tempCheck)
                    {
                        UIManager.UIinstance.WakeUpShapeButton();
                        tempCheck = false;
                    }
                }
            }
        }
    }

    void ChangePlate()
    {
        float rand = Random.Range(0f, 1f);
        if (rand < .5f)
        {
            currentPlate = 0;
            thePlateMF.mesh = squarePlate;
        }
        else
        {
            currentPlate = 1;
            thePlateMF.mesh = altPlate;
        }
        ChangeMat();
    }

    void ChangeMat()
    {
        float rand = Random.Range(0f, 1f);
        if (rand < .6f)
        {
            plateMeshRend.material.color = LerpBackgroundColour.instance.extremeOne;
            currentMat = 0;
        }
        else
        {
            plateMeshRend.material.color = LerpBackgroundColour.instance.extremeTwo;
            currentMat = 1;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (MenuActivator.menuSwitch == 1)
        {
            if (other.CompareTag(Globals.PLAYER))
            {
                switch (PlayerManager.playerStates)
                {
                    // if player is square
                    case 0:
                        // if plate is square
                        if (currentPlate == 0)
                        {
                            if (plateMeshRend.material.color == LerpBackgroundColour.instance.extremeOne)
                            {
                                if (PlayerManager.playerMat == 0)
                                {
                                    UIManager.UIinstance.AdjustScore();
                                }
                                else
                                {
                                    MenuActivator.menuSwitch = 0;
                                    UIManager.UIinstance.StartCoroutine(Globals.GAMEOVER);
                                }
                            }
                            else
                            {
                                if (PlayerManager.playerMat == 1)
                                {
                                    UIManager.UIinstance.AdjustScore();
                                }
                                else
                                {
                                    MenuActivator.menuSwitch = 0;
                                    UIManager.UIinstance.StartCoroutine(Globals.GAMEOVER);
                                }
                            }
                            // great
                        }
                        else
                        {
                            MenuActivator.menuSwitch = 0;
                            UIManager.UIinstance.StartCoroutine(Globals.GAMEOVER);
                            // boo
                        }
                        break;
                    case 1:
                        if (currentPlate == 1)
                        {
                            if (plateMeshRend.material.color == LerpBackgroundColour.instance.extremeTwo)
                            {
                                if (PlayerManager.playerMat == 1)
                                {
                                    UIManager.UIinstance.AdjustScore();
                                }
                                else
                                {
                                    MenuActivator.menuSwitch = 0;
                                    UIManager.UIinstance.StartCoroutine(Globals.GAMEOVER);
                                }
                            }
                            else
                            {
                                if (PlayerManager.playerMat == 0)
                                {
                                    UIManager.UIinstance.AdjustScore();
                                }
                                else
                                {
                                    MenuActivator.menuSwitch = 0;
                                    UIManager.UIinstance.StartCoroutine(Globals.GAMEOVER);
                                }
                            }
                        }
                        else
                        {
                            MenuActivator.menuSwitch = 0;
                            UIManager.UIinstance.StartCoroutine(Globals.GAMEOVER);
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
