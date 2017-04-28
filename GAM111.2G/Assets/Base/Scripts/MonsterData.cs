using UnityEngine;
using System.Collections.Generic;

/*
Simple data used to define the stats of a monster
*/
[CreateAssetMenu()]
public class MonsterData : ScriptableObject
{
    [System.Serializable]
    public class MonsterDataDB
    {
        public List<MonsterDataEntry> entires = new List<MonsterDataEntry>();
    }
    
    [System.Serializable]
    public class MonsterDataEntry
    {
        public string name;
        public MonsterStats stats;
    }

    [System.Serializable]
    public struct MonsterStats
    {
        public int HP, Att, Def;
    }
 
    public MonsterDataDB data;
}
