using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangePage : MonoBehaviour
{
    public string homeScene;
    public Transform mainLevel, playButton, chooseIcon, chooseLevel;

    // main page to choose stage
    public void PlayButton(bool clicked)
    {
        if(clicked == true)
        {
            chooseIcon.gameObject.SetActive(clicked);
            playButton.gameObject.SetActive(true);
        }
        else
        {
            chooseIcon.gameObject.SetActive(clicked);
            playButton.gameObject.SetActive(true);
        }
    }

    // to choose other level *home
    public void goHome()
    {
        SceneManager.LoadScene(homeScene);
    }
}
