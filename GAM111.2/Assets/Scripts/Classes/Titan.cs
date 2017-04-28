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

    void takeDamage(int damageTaken)
    {
        titanHealth = titanHealth - damageTaken;
    }

    void dealHulkSmash(int hulkSmash, int targetHealth)
    {
        targetHealth = targetHealth - hulkSmash;
    }

    void dealHulkSmashAOE(int hulkSmashAOE, int targetHealth)
    {
        targetHealth = targetHealth - hulkSmashAOE;
    }

    void dealArmourUp(int incomingDamage, int damageTaken)
    {
        damageTaken = incomingDamage / 2;
    }

    void Start ()
    {
		
	}
		
	void Update ()
    {
        
    }
}
