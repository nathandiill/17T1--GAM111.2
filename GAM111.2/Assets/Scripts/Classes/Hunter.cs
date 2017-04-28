using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter : MasterClass {

    public static Hunter Instance;

    void Awake()
    {
        Instance = this;
    }

    public int hunterHealth = 50;
    public int exposedAttack = 7;
    public int exposedAttackSD = 3;
    public float dodgeThis;

	void Start ()
    {
		
	}
	
	
	void Update ()
    {
		
	}
}
