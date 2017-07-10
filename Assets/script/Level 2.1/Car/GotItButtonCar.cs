using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotItButtonCar : MonoBehaviour {

    public Transform gotItButton, descPanel, carPage;

    public void GotItButton(bool clicked)
    {
        if (clicked == true)
        {
            descPanel.gameObject.SetActive(clicked);
            gotItButton.gameObject.SetActive(true);

            carPage.gameObject.SetActive(false);
        }
        else
        {
            descPanel.gameObject.SetActive(clicked);
            gotItButton.gameObject.SetActive(true);
        }
    }
}
