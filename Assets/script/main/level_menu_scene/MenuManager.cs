using Assets.script.others.entity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {
    public List<LevelMenu> levels;

    private User userData;

    private void Start()
    {
        foreach (LevelMenu level in levels)
            level.stat_levelMenu = States.StateLevelMenu.DISABLED;

        // load user data here

        /* set level menu status in userData like this
        for(int x=0; x<levels.Count; x++)
            levels[x].stat_levelMenu = userData.LevelStates[x];
        */

        // example
        levels[0].stat_levelMenu = States.StateLevelMenu.ENABLED;
    }
}
