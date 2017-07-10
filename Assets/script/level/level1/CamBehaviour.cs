using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CamBehaviour : MonoBehaviour { // behaviour of the cam
    private AudioSource audioSource; // source of the audio
    private Camera camProp; // camera properties

    private float initCamOrthoSize; // initial com orthographic size
    private Vector3 initPosition; // initial cam position

    // behaviour methods
    private void Awake() // initialize private component variables
    {
        audioSource = GetComponent<AudioSource>();
        camProp = GetComponent<Camera>();
    }

    private void Start() // initialize private variables
    {
        initCamOrthoSize = camProp.orthographicSize;
        initPosition = transform.position;
    }

    // other methods
    public void playSound(AudioClip sound) // play a sound as passed in the parameters
    {
        audioSource.PlayOneShot(sound);
    }

    public void zoomIn(GameObject go) // zoom in the camera towards the 'go'
    {
        transform.position = new Vector3(go.transform.position.x, go.transform.position.y, transform.position.z); // move cam to the clicked object
        camProp.orthographicSize = camProp.orthographicSize / 1.5f; // zoom the cam to the clicked obj
    }

    public void zoomOut() // zoom out the camera and go to initial ortho size and position
    {
        transform.position = initPosition;
        camProp.orthographicSize = initCamOrthoSize;
    }
}
