using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class ClickSound : MonoBehaviour {

    public AudioClip sound;

    private Button button
    {
        get
        {
            return GetComponent<Button>();
        }
    }

    private AudioSource source
    {
        get
        {
            return GetComponent<AudioSource>();
        }
    }

	// Use this for initialization
	void Start ()
    { 
	    gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.playOnAwake = false;
        //Any other settings you want to initialize...
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Test saja");
            source.PlayOneShot(sound);
        }
    }
}
