using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

using Assets.script.others;

namespace Assets.script.others.entity
{
    [XmlRoot("UserData")]
    public class User
    {
        private string username;

        [XmlArray("Levels")]
        [XmlArrayItem("LevelState")]
        private List<States.StateLevelMenu> levelStates = new List<States.StateLevelMenu>();

        public string Username { get; set; }
        public List<States.StateLevelMenu> LevelStates { get; set; }
    }
}
