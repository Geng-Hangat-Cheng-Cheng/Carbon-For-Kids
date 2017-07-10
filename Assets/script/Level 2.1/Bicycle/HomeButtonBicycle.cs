using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeButtonBicycle : MonoBehaviour {

    public Transform homeButton, chooseLevel, descBicycle ;

    public void HomeBicycle(bool clicked)
    {
        if (clicked == true)
        {
            chooseLevel.gameObject.SetActive(clicked);
            homeButton.gameObject.SetActive(true);

            descBicycle.gameObject.SetActive(false);
        }
        else
        {
            chooseLevel.gameObject.SetActive(clicked);
            homeButton.gameObject.SetActive(true);
        }
    }
}
