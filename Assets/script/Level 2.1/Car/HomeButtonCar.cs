using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeButtonCar : MonoBehaviour {

    public Transform homeButton, chooseLevel, descCar;

    public void HomeCar(bool clicked)
    {
        if (clicked == true)
        {
            chooseLevel.gameObject.SetActive(clicked);
            homeButton.gameObject.SetActive(true);

            descCar.gameObject.SetActive(false);
        }
        else
        {
            chooseLevel.gameObject.SetActive(clicked);
            homeButton.gameObject.SetActive(true);
        }
    }
}
