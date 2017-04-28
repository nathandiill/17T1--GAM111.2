using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterClass : MonoBehaviour {

    public int attack = 5;
    public GameObject[] Shooter;
    public GameObject[] Target;
	
	void Start ()
    {
		
	}
	

	void Update ()
    {
		if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.Log(hit.transform.gameObject.name);
            }
        }
	}

    void standardAttack(int attack)
    {
        
    }
    public Slot mySlot;

    public Renderer myRenderer;

    //int actionsRemaining

    public int monsterDataEntryIndex = 0;
    public ClassData.ClassDataEntry myEntry
    {
        get
        {
            return GameData.Instance.monsterData.data.entires[monsterDataEntryIndex];
        }
        set
        {
            monsterDataEntryIndex = GameData.Instance.monsterData.data.entires.IndexOf(value);
        }
    }
    public ClassData.ClassStats currentStats;

    public enum Mode
    {
        Attack,
        Defend,
        Dodge
    }

    Mode _mode;

    public Mode CurrentMode
    {
        get
        {
            return _mode;
        }
        set
        {
            _mode = value;
        }
    }

    public bool IsDead
    {
        get
        {
            return currentStats.HP <= 0;
        }
    }

    public bool IsAlive
    {
        get
        {
            return currentStats.HP > 0;
        }
    }

    public void Init(Slot s)
    {
        mySlot = s;
        s.activeClass = this;
        currentStats = myEntry.stats;
        myRenderer = GetComponent<Renderer>();
    }

    public void GoIdle()
    {
        var c = myRenderer.material.color;
        c.a = 0.5f;
        myRenderer.material.color = c;
    }

    public void GoActive()
    {
        var c = myRenderer.material.color;
        c.a = 1;
        myRenderer.material.color = c;
    }

    public void TakeDamage(int dmg)
    {
        currentStats.HP -= dmg;
        //EFFECTS!!!!!

        //different effect for dead
    }

    //something needs to use this
    public static void ResolveMonsterConflict(MasterClass att, MasterClass def)
    {
        def.TakeDamage(CalcDamage(att, def));

        if (def.IsAlive)
            att.TakeDamage(CalcDamage(def, att));
    }

    public static int CalcDamage(MasterClass att, MasterClass def)
    {
        int dmgDone = att.currentStats.Att - def.currentStats.Def;
        dmgDone = Mathf.Max(1, dmgDone);
        return dmgDone;
    }
}
