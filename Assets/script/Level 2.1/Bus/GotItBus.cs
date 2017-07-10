using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotItBus : MonoBehaviour {

    public Transform gotItButton, descPanel, busPage;

    public void GotItButton(bool clicked)
    {
        if (clicked == true)
        {
            descPanel.gameObject.SetActive(clicked);
            gotItButton.gameObject.SetActive(true);

            busPage.gameObject.SetActive(false);
        }
        else
        {
            gotItButton.gameObject.SetActive(clicked);
            descPanel.gameObject.SetActive(true);
        }
    }
}
