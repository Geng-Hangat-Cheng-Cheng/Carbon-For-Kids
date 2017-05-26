using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    
    //ref object 
    public Transform mainMenu, settingsMenu, aboutMenu;

    public AudioSource source;
    public AudioClip hover;
    public AudioClip click;

    //load level
    public void LoadScene()
    {
        SceneManager.LoadScene("Other Scene");
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

    public void Onhover()
    {
        source.PlayOneShot(hover);
    }

    public void OnClick()
    {
        source.PlayOneShot(click);
    }

}
