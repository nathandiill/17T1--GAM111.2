using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassData : MonoBehaviour {
    [System.Serializable]
    public class ClassDataDB
    {
        public List<ClassDataEntry> entires = new List<ClassDataEntry>();
    }

    [System.Serializable]
    public class ClassDataEntry
    {
        public string name;
        public ClassStats stats;
    }

    [System.Serializable]
    public struct ClassStats
    {
        public int HP, Att, Def;
    }

    public ClassDataDB data;
}
