using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelMenu : MonoBehaviour {
    public string sceneLvlName;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>(); // get animator component
    }

    private void LateUpdate()
    {
        // if current animation is triggered, set it off
        if (animator.GetBool("triggered"))
            animator.SetBool("triggered", false);
    }

    private void OnMouseDown()
    {
        // if user clicked, goto level scene and trigger animation
        if (Input.GetKey(KeyCode.Mouse0)) {
            animator.SetBool("triggered", true);
            // SceneManager.LoadScene(sceneLvlName);
            Debug.Log("Go to scene: " + sceneLvlName);
        }
    }
}
