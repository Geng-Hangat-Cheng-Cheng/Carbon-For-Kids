using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotItButtonBicycle : MonoBehaviour {

    public Transform gotItButton, descPanel, bicyclePage;

    public void GotItButton(bool clicked)
    {
        if (clicked == true)
        {
            descPanel.gameObject.SetActive(clicked);
            gotItButton.gameObject.SetActive(true);

            bicyclePage.gameObject.SetActive(false);
        }
        else
        {
            descPanel.gameObject.SetActive(clicked);
            gotItButton.gameObject.SetActive(true);
        }
    }
}
