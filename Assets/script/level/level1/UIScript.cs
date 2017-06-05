using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIScript: MonoBehaviour {
    public GameObject goCanvStartGame, goCanvInGame, goCanvEndGame;

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

    public void exitLevel()
    {
        // dissable all of ui
        goCanvStartGame.SetActive(false);
        goCanvInGame.SetActive(false);
        goCanvEndGame.SetActive(false);

        // save level completion data here (into serializable object)


        SceneManager.LoadScene("scene_lvlMenu"); // goto level select screen
    }
}
