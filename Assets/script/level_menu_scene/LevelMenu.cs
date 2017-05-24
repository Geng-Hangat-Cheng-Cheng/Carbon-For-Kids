using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelMenu : MonoBehaviour {
    public string sceneLvlName;

    private void OnMouseDown()
    {
        if (Input.GetKey(KeyCode.Mouse0))
            // SceneManager.LoadScene(sceneLvlName);
            Debug.Log("Go to scene: " + sceneLvlName);
    }
}
