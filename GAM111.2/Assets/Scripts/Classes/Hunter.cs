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

    void takeDamage(int damageTaken)
    {
        hunterHealth = hunterHealth - damageTaken;
    }

    void dealExposedAttack(int exposedAttack, int targetHealth)
    {
        targetHealth = targetHealth - exposedAttack;
    }

    void dealExposedAttackSD(int exposedAttackSD, int hunterHealth)
    {
        hunterHealth = hunterHealth - exposedAttackSD;
    }

    void dealDodgeThis(int incomingDamage, int targetHealth)
    {
        int chanceRoll = UnityEngine.Random.Range(1, 101);
        if (chanceRoll <= 100)
        {
            incomingDamage = 0;
        }
        else
        {
            targetHealth = targetHealth - incomingDamage;
        }
    }

    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}
}
