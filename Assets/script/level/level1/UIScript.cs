using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIScript: MonoBehaviour {
    public AudioClip auBtnClick;
    public GameObject goCanvStartGame, goCanvInGame, goCanvEndGame;

    private DataManager dataManager;
    private AudioSource audioSource;

    private void Awake()
    {
        dataManager = GetComponent<DataManager>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        transform.position = goCanvStartGame.GetComponent<Transform>().position; // set the pos of cam to the start canvas

        // only start canvas can be seen
        goCanvStartGame.SetActive(true);
        goCanvInGame.SetActive(false);
        goCanvEndGame.SetActive(false);
    }

    public void startGame()
    {
        transform.position = goCanvInGame.GetComponent<Transform>().position; // set the pos of cam to the in game canvas

        // only in game canvas can be seen
        goCanvStartGame.SetActive(false);
        goCanvInGame.SetActive(true);
        goCanvEndGame.SetActive(false);
    }

    public void endGame()
    {
        transform.position = goCanvEndGame.GetComponent<Transform>().position; // set the pos of cam to the end canvas

        // only end canvas can be seen
        goCanvStartGame.SetActive(false);
        goCanvInGame.SetActive(false);
        goCanvEndGame.SetActive(true);
    }

    public void exitLevel(string sceneToLoad)
    {
        User data;
        string fileName;

        // dissable all of ui
        goCanvStartGame.SetActive(false);
        goCanvInGame.SetActive(false);
        goCanvEndGame.SetActive(false);

        // save level completion data here (into serializable object)
        fileName = "user-data";
        data = dataManager.loadData<User>(fileName);

        if (data == null)
            data = new User();

        // change user states
        data.levelStates[0] = States.StateLevelMenu.COMPLETED;
        if(data.levelStates[1] == States.StateLevelMenu.DISABLED)
        {
            data.levelStates[1] = States.StateLevelMenu.ENABLED;
            data.levelStates[2] = States.StateLevelMenu.ENABLED;
            data.levelStates[3] = States.StateLevelMenu.ENABLED;
            data.levelStates[4] = States.StateLevelMenu.ENABLED;
        }

        dataManager.saveData<User>(fileName, data); // save user data

        SceneManager.LoadScene(sceneToLoad); // goto level select screen
    }

    public void playBtnClick()
    {
        audioSource.PlayOneShot(auBtnClick); // play audio
    }

    public void gotoScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
