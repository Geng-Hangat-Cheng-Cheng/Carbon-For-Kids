using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ObjectBehaviour : MonoBehaviour { // behaviour of each of the objects in level 1
    public bool activated; // the state of the object
    public string title, desc; // the title and description for the oobject

    public AudioSource audioSource; // audio source
    public AudioClip clickSFX; // SFX for clicking the object

    public CamBehaviour camBehaviour; // behaviour of the cam
    public UIBehaviour uiBehaviour; // behaviour of the UI

    private Animator animator; // animator for the objects

    // behaviour methods
    private void Awake() // initialize private component variables
    {
        animator = GetComponent<Animator>();
    }

    private void OnMouseDown() // activate the object when player click the object
    {
        if (Input.GetKey(KeyCode.Mouse0))
            if (!EventSystem.current.IsPointerOverGameObject())
                activateObj();
    }

    // other methods
    public void activateObj() // activate the object by zoom into the object, show sub UI for the object and change the animation of the object
    {
        activated = true;

        audioSource.PlayOneShot(clickSFX);
        playActivated();

        camBehaviour.zoomIn(this.gameObject);
        uiBehaviour.showSubUI(title, desc);
    }

    public void deactivateObj() // deactivate the object by changing the animation of the object to idle
    {
        playIdle();
    }

    private void playIdle() // change the animation of the object to idle
    {
        animator.SetBool("click", false);
    }

    private void playActivated() // change the animation for the object to activated
    {
        animator.SetBool("click", true);
    }
}
