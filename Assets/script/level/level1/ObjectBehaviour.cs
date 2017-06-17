using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ObjectBehaviour : MonoBehaviour {
    public bool activated;
    public string title, desc;

    public AudioSource audioSource;
    public AudioClip clickSFX;

    public CamBehaviour camBehaviour;
    public UIBehaviour uiBehaviour;

    private Animator animator;

    // behaviour methods
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        if (Input.GetKey(KeyCode.Mouse0))
            if (!EventSystem.current.IsPointerOverGameObject())
                activateObj();
    }

    // other methods
    public void activateObj()
    {
        activated = true;

        audioSource.PlayOneShot(clickSFX);
        playActivated();

        camBehaviour.zoomIn(this.gameObject);
        uiBehaviour.showSubUI(title, desc);
    }

    public void deactivateObj()
    {
        playIdle();
    }

    private void playIdle()
    {
        animator.SetBool("click", false);
    }

    private void playActivated()
    {
        animator.SetBool("click", true);
    }
}
