using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelMenu : MonoBehaviour {
    public string sceneLvlName;
    public States.StateLevelMenu stat_levelMenu;
    public Sprite completedImg, enabledImg, disabledImg;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        switch(stat_levelMenu)
        {
            case States.StateLevelMenu.COMPLETED:
                spriteRenderer.sprite = completedImg;
                break;
            case States.StateLevelMenu.ENABLED:
                spriteRenderer.sprite = enabledImg;
                break;
            case States.StateLevelMenu.DISABLED:
                spriteRenderer.sprite = disabledImg;
                break;
        }
    }

    private void OnMouseDown()
    {
        // if user clicked, goto level scene and trigger animation
        if (Input.GetKey(KeyCode.Mouse0))
            // SceneManager.LoadScene(sceneLvlName);
            Debug.Log("Go to scene: " + sceneLvlName);
    }
}
