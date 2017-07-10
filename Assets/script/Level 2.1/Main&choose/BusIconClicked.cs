using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusIconClicked : MonoBehaviour {

    public Transform chooseBus, busPage, chooseLevel;

    public void ChooseBus(bool clicked)
    {
        if (clicked == true)
        {
            busPage.gameObject.SetActive(clicked);
            chooseBus.gameObject.SetActive(true);

            chooseLevel.gameObject.SetActive(false);

        }
        else
        {
            busPage.gameObject.SetActive(clicked);
            chooseBus.gameObject.SetActive(true);
        }
    }

}
