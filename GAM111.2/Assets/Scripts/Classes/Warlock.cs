using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warlock : MasterClass {

    public static Warlock Instance;

    void Awake()
    {
        Instance = this;
    }

    public int warlockHealth = 40;
    public int novaBomb = 1;
    public int radiance = 6;
	
	void Start ()
    {
		
	}
	
	
	void Update ()
    {
		
	}
}
