using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;
using System;

public class DataManager : MonoBehaviour {
    public string path;

    public void saveData<T>(string fileName, T data)
    {
        string json;
        StreamWriter sw;

        json = JsonUtility.ToJson(data, true);
        sw = new StreamWriter(path + fileName + ".json");

        sw.WriteLine(json); // write json object
        sw.Close();
    }

    public T loadData<T>(string fileName)
    {
        string json;

        if (!File.Exists(path + fileName + ".json"))
            return default(T);

        json = File.ReadAllText(path + fileName + ".json");

        return JsonUtility.FromJson<T>(json); // return as object
    }
}

// model classes
[Serializable]
public class User
{
    public States.StateLevelMenu[] levelStates;

    public User()
    {
        levelStates = new States.StateLevelMenu[]
        {
            States.StateLevelMenu.ENABLED,
            States.StateLevelMenu.DISABLED,
            States.StateLevelMenu.DISABLED,
            States.StateLevelMenu.DISABLED,
            States.StateLevelMenu.DISABLED,
            States.StateLevelMenu.DISABLED
        };
    }
}
