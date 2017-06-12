using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CamFocus : MonoBehaviour {
    public float lerpTime, uiPosX, uiPosY;
    public GameObject uiDesc;
    public Text uiObjTitle, uiObjDesc; // ui for object description
    public AudioClip auObjClick;

    private Camera camProp;
    private float initOrthoSize;
    private Vector3 initCamPos;

    private string objTitle, objDescription;
    private int currentMenu;
    private bool gameCompleted;
    private bool[] menuStat;

    private Animator goAnimator;
    private AudioSource audioSource;

    // basic methods
    private void Awake()
    {
        camProp = GetComponent<Camera>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        // make the ui invisible
        uiDesc.SetActive(false);
        uiObjTitle.GetComponent<Text>().text = "";
        uiObjDesc.GetComponent<Text>().text = "";

        // init cam
        initOrthoSize = camProp.orthographicSize;
        initCamPos = transform.position;

        // init game stat
        currentMenu = 0;
        gameCompleted = false;
        menuStat = new bool[5];
    }

    private void Update()
    {
        // check for input
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(!EventSystem.current.IsPointerOverGameObject())
            {
                GameObject clickedGO = getClickedGO(); // get clicked gameobject

                if (clickedGO != null)
                    if (clickedGO.layer == LayerMask.NameToLayer("touch"))
                    {
                        goAnimator = clickedGO.GetComponent<Animator>();
                        audioSource.PlayOneShot(auObjClick); // play sound

                        switch (clickedGO.tag) // load description for the menus
                        {
                            case "menu_people":
                                currentMenu = 0;
                                objTitle = "People";
                                objDescription = "This is people and animal.";
                                break;
                            case "menu_tree":
                                currentMenu = 1;
                                objTitle = "Tree";
                                objDescription = "This is tree.";
                                break;
                            case "menu_water":
                                currentMenu = 2;
                                objTitle = "Water";
                                objDescription = "This is water.";
                                break;
                            case "menu_mineral":
                                currentMenu = 3;
                                objTitle = "Mineral";
                                objDescription = "This is mineral.";
                                break;
                            case "menu_wind":
                                currentMenu = 4;
                                objTitle = "Wind";
                                objDescription = "This is wind.";
                                break;
                        }

                        Transform clickedGoTrans = clickedGO.GetComponent<Transform>(); // get transform component of clicked gameobject

                        transform.position = new Vector3(clickedGoTrans.position.x + uiPosX, clickedGoTrans.position.y + uiPosY, transform.position.z); // move cam to the clicked object
                        camProp.orthographicSize = camProp.orthographicSize / 1.5f; // zoom the cam to the clicked obj
                        goAnimator.SetBool("click", true); // do animation for clicked object

                        // show ui for the clicked obj
                        uiObjTitle.GetComponent<Text>().text = objTitle; // set obj ui for title
                        uiObjDesc.GetComponent<Text>().text = objDescription; // set obj ui for description
                        uiDesc.SetActive(true); // show ui
                    }
            }
        }

        checkGameStat(); // check the game status
    }

    // other methods
    public void updateMenuStat() // update the status of each menu
    {
        menuStat[currentMenu] = true;

        uiDesc.SetActive(false);
        camProp.orthographicSize = initOrthoSize;
        transform.position = initCamPos;
    }

    private void checkGameStat() // check whether the game has been completed or not
    {
        // check if all of the menu has been done or not
        foreach(bool val in menuStat)
        {
            if (!val)
            {
                gameCompleted = false;
                return;
            }
            else
                gameCompleted = true;
        }

        if (gameCompleted)
        {
            UIScript uiScript;

            uiScript = GetComponent<UIScript>();
            uiScript.endGame();
        }
    }

    public void stopAnimation()
    {
        goAnimator.SetBool("click", false);
    }

    private GameObject getClickedGO() // get the gameobject when being clicked
    {
        Ray rayInfo;
        RaycastHit2D hitInfo;

        rayInfo = Camera.main.ScreenPointToRay(Input.mousePosition);
        hitInfo = Physics2D.GetRayIntersection(rayInfo, Mathf.Infinity);

        if (hitInfo)
            return hitInfo.collider.gameObject;
        else
            return null;
    }
}
