using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBehaviour : MonoBehaviour {
    public List<GameObject> mainUIs;
    public GameObject subUI;

    public Text title, description;

    // behaviour methods
    private void Start()
    {
        hideMainUI();
        hideSubUI();
    }

    // other methods
    public void showMainUI(int mainUICode)
    {
        mainUIs[mainUICode].SetActive(true);
    }

    public void showSubUI(string title, string description)
    {
        this.title.text = title;
        this.description.text = description;

        subUI.SetActive(true);
    }

    public void hideMainUI()
    {
        foreach (GameObject ui in mainUIs)
            ui.SetActive(false);
    }

    public void hideSubUI()
    {
        subUI.SetActive(false);
    }
}
