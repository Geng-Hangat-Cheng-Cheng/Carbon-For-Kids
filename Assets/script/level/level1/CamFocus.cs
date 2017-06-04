using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CamFocus : MonoBehaviour {
    public float lerpTime;
    public GameObject uiDesc;
    public Text uiObjTitle, uiObjDesc; // ui for object description

    private Camera camProp;
    private float initOrthoSize;
    private Vector3 initCamPos;

    private string objTitle, objDescription;
    private int currentMenu;
    private bool gameCompleted;
    private bool[] menuStat;

    // basic methods
    private void Awake()
    {
        camProp = GetComponent<Camera>();
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

        // game stat
        currentMenu = 0;
        gameCompleted = false;
        menuStat = new bool[5];
    }

    private void Update()
    {
        // check for input
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject clickedGO;

            clickedGO = getClickedGO();

            if (clickedGO != null)
                if(clickedGO.layer == LayerMask.NameToLayer("touch"))
                {
                    // load description for the menus
                    switch (clickedGO.tag)
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
                    
                    transform.position = Vector3.Lerp(transform.position, clickedGO.GetComponent<Transform>().position, lerpTime); // move cam to the clicked object
                    
                    camProp.orthographicSize = camProp.orthographicSize / 1.5f; // zoom the cam to the clicked obj
                    transform.position = initCamPos; // prevent the z-values to change

                    // show ui for the clicked obj
                    uiObjTitle.GetComponent<Text>().text = objTitle; // set obj ui for title
                    uiObjDesc.GetComponent<Text>().text = objDescription; // set obj ui for description
                    uiDesc.SetActive(true);
                }
        }

        checkGameStat();
    }

    // other methods
    public void updateMenuStat()
    {
        menuStat[currentMenu] = true;

        uiDesc.SetActive(false);
        camProp.orthographicSize = initOrthoSize;
        transform.position = initCamPos;
    }

    private void checkGameStat()
    {
        // check if all of the menu has been done or not
        foreach(bool val in menuStat)
        {
            if (!val)
            {
                gameCompleted = false;
                break;
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

    private GameObject getClickedGO()
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
