using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript: MonoBehaviour {
    public GameObject goCanvStartGame, goCanvInGame, goCanvEndGame;

    private void Start()
    {
        transform.position = goCanvStartGame.GetComponent<Transform>().position;

        goCanvStartGame.SetActive(true);
        goCanvInGame.SetActive(false);
        goCanvEndGame.SetActive(false);
    }

    public void startGame()
    {
        transform.position = goCanvInGame.GetComponent<Transform>().position;

        if (!goCanvInGame.activeSelf)
        {
            goCanvStartGame.SetActive(false);
            goCanvInGame.SetActive(true);
            goCanvEndGame.SetActive(false);
        }
    }

    public void endGame()
    {
        transform.position = goCanvEndGame.GetComponent<Transform>().position;

        if (!goCanvEndGame.activeSelf)
        {
            goCanvStartGame.SetActive(false);
            goCanvInGame.SetActive(false);
            goCanvEndGame.SetActive(true);
        }
    }

    public void exitLevel()
    {

    }
}
