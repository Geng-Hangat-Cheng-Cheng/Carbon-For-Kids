using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CamBehaviour : MonoBehaviour {
    private AudioSource audioSource;
    private Camera camProp;

    private float initCamOrthoSize;
    private Vector3 initPosition;

    // behaviour methods
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        camProp = GetComponent<Camera>();
    }

    private void Start()
    {
        initCamOrthoSize = camProp.orthographicSize;
        initPosition = transform.position;
    }

    // other methods
    public void playSound(AudioClip sound)
    {
        audioSource.PlayOneShot(sound);
    }

    public void zoomIn(GameObject go)
    {
        transform.position = new Vector3(go.transform.position.x, go.transform.position.y, transform.position.z); // move cam to the clicked object
        camProp.orthographicSize = camProp.orthographicSize / 1.5f; // zoom the cam to the clicked obj
    }

    public void zoomOut()
    {
        transform.position = initPosition;
        camProp.orthographicSize = initCamOrthoSize;
    }
}
