using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehaviour : MonoBehaviour { // behaviour of the level 1 game
    public string homeScene; // the scene name for home scene
    public List<ObjectBehaviour> objActivated; // list of behaviour for each object
    public UIBehaviour uiBehaviour; // behaviour for UI

    private DataManager dataManager; // data manager to save user data

    // behaviour methods
    private void Awake() // initialize private variables
    {
        dataManager = GetComponent<DataManager>();
    }

    // other methods
    public void checkCompletion(int endUICode) // check whether the user has completed the level 1 or not
    {
        foreach (ObjectBehaviour obj in objActivated)
            if (!obj.activated)
                return;

        uiBehaviour.showMainUI(endUICode);
    }

    public void changeScene(string sceneName) // change the scene according to the 'sceneName'
    {
        SceneManager.LoadScene(sceneName);
    }

    public void exitLevel(string sceneToLoad) // exit the level and goto other scene according to the 'sceneToLoad'
    {
        User data;
        string fileName;

        // save level completion data here (into serializable object)
        fileName = "user-data";
        data = dataManager.loadData<User>(fileName);

        if (data == null)
            data = new User();

        // change user states
        data.levelStates[0] = States.StateLevelMenu.COMPLETED;
        if (data.levelStates[1] == States.StateLevelMenu.DISABLED)
        {
            data.levelStates[1] = States.StateLevelMenu.ENABLED;
            data.levelStates[2] = States.StateLevelMenu.ENABLED;
            data.levelStates[3] = States.StateLevelMenu.ENABLED;
            data.levelStates[4] = States.StateLevelMenu.ENABLED;
        }

        dataManager.saveData<User>(fileName, data); // save user data

        SceneManager.LoadScene(sceneToLoad); // goto level select screen
    }
}
