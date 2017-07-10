using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BicycleIconClick : MonoBehaviour {

    public Transform chooseBicycle, bicyclePage, chooseLevel;

    public void ChooseBicycle(bool clicked)
    {
        if (clicked == true)
        {
            bicyclePage.gameObject.SetActive(clicked);
            chooseBicycle.gameObject.SetActive(true);

            chooseLevel.gameObject.SetActive(false);
        }
        else
        {
            bicyclePage.gameObject.SetActive(clicked);
            chooseBicycle.gameObject.SetActive(true);
        }
    }
}
