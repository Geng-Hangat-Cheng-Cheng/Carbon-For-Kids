using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeVolumeSound : MonoBehaviour {

    public Slider Volume;
    public AudioSource myMusic;
	
	// Update is called once per frame
	public void Update () {
        myMusic.volume = Volume.value;
	}
}
