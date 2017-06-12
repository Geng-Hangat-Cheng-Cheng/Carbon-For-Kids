using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MenuManager : MonoBehaviour {
    public List<LevelMenu> levels;

    private User userData;
    private DataManager dataManager;

    private void Awake()
    {
        dataManager = GetComponent<DataManager>();
    }

    private void Start()
    {
        string fileName;

        // load user data here
        fileName = "user-data";
        userData = dataManager.loadData<User>(fileName);

        if (userData == null)
        {
            userData = new User();
            dataManager.saveData<User>(fileName, userData);
        }

        // initialize state of each level according to user data
        for (int x=0; x<levels.Count; x++)
            levels[x].stat_levelMenu = userData.levelStates[x];
    }
}
