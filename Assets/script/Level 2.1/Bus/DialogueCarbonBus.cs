﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class DialogueCarbonBus : MonoBehaviour
{
    private Text _textComponent;

    public string[] DialogueStrings;

    public float SecondsBetweenCharacters = 0.1f;

    // Use this for initialization
    void Start()
    {
        _textComponent = GetComponent<Text>();
        _textComponent.text = " ";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(DisplayString(DialogueStrings[0]));

        }

    }


    private IEnumerator DisplayString(string stringToDisplay)
    {
        int stringLength = stringToDisplay.Length;
        int currentCharacterIndex = 0;

        _textComponent.text = "";

        while (currentCharacterIndex < stringLength)
        {
            _textComponent.text += stringToDisplay[currentCharacterIndex];
            currentCharacterIndex++;

            if (currentCharacterIndex < stringLength)
            {
                yield return new WaitForSeconds(SecondsBetweenCharacters);
            }
            else
            {
                break;
            }
        }
        _textComponent.text = "Carbon footprint value = 0,4гр/1km СО2(5)";
    }

}

