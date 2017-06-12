using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelMenu : MonoBehaviour {
    public string sceneLvlName;
    public States.StateLevelMenu stat_levelMenu;
    public Sprite completedImg, enabledImg, disabledImg;

    private Image btnImg;

    private void Awake()
    {
        btnImg = GetComponent<Image>();
    }

    private void Update()
    {
        switch(stat_levelMenu)
        {
            case States.StateLevelMenu.COMPLETED:
                btnImg.sprite = completedImg;
                break;
            case States.StateLevelMenu.ENABLED:
                btnImg.sprite = enabledImg;
                break;
            case States.StateLevelMenu.DISABLED:
                btnImg.sprite = disabledImg;
                break;
        }
    }

    public void gotoNextScene()
    {
        if (stat_levelMenu != States.StateLevelMenu.DISABLED) // if current state of the level is not DISABLED
            SceneManager.LoadScene(sceneLvlName); // if user clicked, goto level scene and trigger animation
    }
}
