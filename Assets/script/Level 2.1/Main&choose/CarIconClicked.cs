using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarIconClicked : MonoBehaviour {

    public Transform chooseCar, carPage, chooseLevel;

    public void ChooseCar(bool clicked)
    {
        if (clicked == true)
        {
            carPage.gameObject.SetActive(clicked);
            chooseCar.gameObject.SetActive(true);

            chooseLevel.gameObject.SetActive(false);
        }
        else
        {
            carPage.gameObject.SetActive(clicked);
            chooseCar.gameObject.SetActive(true);
        }
    }

}
