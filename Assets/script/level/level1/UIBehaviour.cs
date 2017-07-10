using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBehaviour : MonoBehaviour { // behaviour for each UI
    public List<GameObject> mainUIs; // list of main uis
    public GameObject subUI; // the sub ui

    public Text title, description; // title and description for Text (UI) in sub ui

    // behaviour methods
    private void Start() // initialize the UI
    {
        hideMainUI();
        hideSubUI();

        showMainUI(0);
    }

    // other methods
    public void showMainUI(int mainUICode) // Show the main UI (Start, InGame and End) based on their index number as “mainUICode”
    {
        mainUIs[mainUICode].SetActive(true);
    }

    public void showSubUI(string title, string description) // Initialize the value of sub UI based on the parameter and show it to player
    {
        this.title.text = title;
        this.description.text = description;

        subUI.SetActive(true);
    }

    public void hideMainUI() // Hide all Main UIs
    {
        foreach (GameObject ui in mainUIs)
            ui.SetActive(false);
    }

    public void hideSubUI() // Hide the Sub UI
    {
        subUI.SetActive(false);
    }
}
