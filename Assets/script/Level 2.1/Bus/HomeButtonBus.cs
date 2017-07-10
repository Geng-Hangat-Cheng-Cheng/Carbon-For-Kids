using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeButtonBus : MonoBehaviour {

    public Transform homeButton, chooseLevel, descBus;

    public void HomeBus(bool clicked)
    {
        if (clicked == true)
        {
            chooseLevel.gameObject.SetActive(clicked);
            homeButton.gameObject.SetActive(true);

            descBus.gameObject.SetActive(false);
        }
        else
        {
            chooseLevel.gameObject.SetActive(clicked);
            homeButton.gameObject.SetActive(true);
        }
    }

}
