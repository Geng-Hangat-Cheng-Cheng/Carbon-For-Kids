using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehaviour : MonoBehaviour {
    public string homeScene;
    public List<ObjectBehaviour> objActivated;

    public UIBehaviour uiBehaviour;

    private DataManager dataManager;

    // behaviour methods
    private void Awake()
    {
        dataManager = GetComponent<DataManager>();
    }

    // other methods
    public void checkCompletion()
    {
        foreach (ObjectBehaviour obj in objActivated)
            if (!obj.activated)
                return;

        uiBehaviour.showMainUI(1);
    }

    public void exitLevel(string sceneToLoad)
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
