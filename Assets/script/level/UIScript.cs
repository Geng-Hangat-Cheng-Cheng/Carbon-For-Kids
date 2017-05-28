using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript: MonoBehaviour {
    public GameObject goCanvStartGame, goCanvInGame, goCanvEndGame;

    private void Start()
    {
        transform.position = goCanvStartGame.GetComponent<Transform>().position;

        if (goCanvStartGame.activeSelf)
            goCanvStartGame.SetActive(true);
        if (goCanvInGame.activeSelf)
            goCanvInGame.SetActive(false);
        if (goCanvEndGame.activeSelf)
            goCanvEndGame.SetActive(false);
    }

    public void startGame()
    {
        transform.position = goCanvInGame.GetComponent<Transform>().position;

        if (!goCanvInGame.activeSelf)
            goCanvInGame.SetActive(true);
    }

    public void endGame()
    {
        transform.position = goCanvEndGame.GetComponent<Transform>().position;

        if (!goCanvEndGame.activeSelf)
            goCanvEndGame.SetActive(true);
    }

    public void exitLevel()
    {

    }
}
