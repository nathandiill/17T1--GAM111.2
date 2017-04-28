using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Titan : MasterClass
{

    public static Titan Instance;

    void Awake()
    {
        Instance = this;
    }

    public int titanHealth = 60;
    public int hulkSmash = 4;
    public int hulkSmashAOE = 1;
    public float armourUp;

    void dealHulkSmash()
    {

    }

    void Start ()
    {
		
	}
		
	void Update ()
    {
        
    }
}
