using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    
    //ref object 
    public Transform mainMenu, settingsMenu, aboutMenu;

    //load levela
    public void LoadScene(string name)
    {
        Application.LoadLevel(name);
    }

    //setting button change
    public void SettingsMenu(bool clicked)
    {
        if(clicked == true)
        {
            settingsMenu.gameObject.SetActive(clicked);
            mainMenu.gameObject.SetActive(false);
        }
        else
        {
            settingsMenu.gameObject.SetActive(clicked);
            mainMenu.gameObject.SetActive(true);
        }
    }

    //about button change
    public void AboutMenu(bool clicked)
    {
        if(clicked == true)
        {
            aboutMenu.gameObject.SetActive(clicked);
            mainMenu.gameObject.SetActive(false);
        }
        else
        {
            aboutMenu.gameObject.SetActive(clicked);
            mainMenu.gameObject.SetActive(true);
        }
    }

}
