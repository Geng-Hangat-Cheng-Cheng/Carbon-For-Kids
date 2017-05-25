using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFocus : MonoBehaviour {
    public Transform transBtnLevel; // overall lvl btn transfom instance
    public float easeTime; // the number of times the easing effect will have
    public int lvlCompleted; // keep track of the level that the player has completed

    private Transform camTransform;
    private Camera cam;

    private void Awake()
    {
        lvlCompleted = 1;

        cam = GetComponent<Camera>();
        camTransform = GetComponent<Transform>();
    }

    private void Start()
    {
        camTransform.position = new Vector3(transBtnLevel.position.x, camTransform.position.y, camTransform.position.z);
        camTransform.localScale = new Vector3(transBtnLevel.localScale.x, camTransform.localScale.y, camTransform.localScale.z);
    }

    private void Update()
    {
        float camSize;
        Vector3 currentPos, destinationPos;
        Transform btnLvl, btnLvl2; // inidividual transform instance for each button

        // initialize
        currentPos = transform.position;
        destinationPos = currentPos;
        camSize = cam.orthographicSize;

        // based on the lvl that the player has completed, the camera view all of the completed level
        switch(lvlCompleted)
        {
            case 1: // view only level 1
                camSize = 2;
                btnLvl = transBtnLevel.transform.Find("btn_lv1");
                destinationPos = new Vector3(btnLvl.position.x, btnLvl.position.y, camTransform.position.z); // get current & destination position
                break;
            case 2: // view only level 1 and 2
                camSize = 4;
                btnLvl = transBtnLevel.transform.Find("btn_lv1");
                btnLvl2 = transBtnLevel.transform.Find("btn_lv2_2");
                destinationPos = new Vector3((btnLvl.position.x - btnLvl2.position.x) / 2, (btnLvl.position.y - btnLvl2.position.y) / 2, camTransform.position.z);
                break;
            case 3: // view all level
                camSize = 6;
                btnLvl = transBtnLevel.transform.Find("btn_lv2_2");
                destinationPos = new Vector3(btnLvl.position.x, btnLvl.position.y, camTransform.position.z);
                break;
        }

        camTransform.position = Vector3.Lerp(currentPos, destinationPos, (1 / easeTime)); // move with ease
        cam.orthographicSize = camSize;
    }
}
