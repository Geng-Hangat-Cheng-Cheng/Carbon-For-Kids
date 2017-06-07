using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;

using Assets.script.others.entity;


public class DataManager : MonoBehaviour {
    public void saveUserData(string path, User userData)
    {
        XmlSerializer serializer;

        serializer = new XmlSerializer(typeof(User)); // init serializer

        // save data
        using (FileStream stream = new FileStream(path, FileMode.Create))
            serializer.Serialize(stream, this);
    }

    public User loadUserData(string path)
    {
        XmlSerializer serializer;

        serializer = new XmlSerializer(typeof(User)); // init serializer

        // load the data
        using (FileStream stream = new FileStream(path, FileMode.Open))
            return serializer.Deserialize(stream) as User;
    }
}
