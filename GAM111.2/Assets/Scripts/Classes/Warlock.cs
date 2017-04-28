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

    void takeDamage(int damageTaken)
    {
        warlockHealth = warlockHealth - damageTaken;
    }

    void dealNovaBomb(int novaBomb, int targetHealth)
    {
        targetHealth = targetHealth - novaBomb;
    }

    void dealRadiance(int radiance, int warlockHealth)
    {
        warlockHealth = warlockHealth + radiance;
    }

    void Start()
    {

    }
	
	void Update ()
    {
		
	}
}
