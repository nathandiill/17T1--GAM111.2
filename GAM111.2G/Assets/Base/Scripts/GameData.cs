using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Simple singleton to hold global data required by other objects.
*/
public class GameData : MonoBehaviour
{

    public MonsterData monsterData;

    static public GameData Instance
    {
        get
        {
            return _instance;
        }
    }

    private static GameData _instance;

    void Awake()
    {
        if (_instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
