using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Represents an instance of a monster. Refers to an entry in the MonsterData is attached to a prefab
    with the appropriate sprite and monster index preset. At creation it is put in a slot.
*/
public class Monster : MonoBehaviour {

	public Slot mySlot;

    public Renderer myRenderer;

    //int actionsRemaining

    public int monsterDataEntryIndex = 0;
    public MonsterData.MonsterDataEntry myEntry
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
    public MonsterData.MonsterStats currentStats;

    public enum Mode
    {
        Attack,
        Defend,
        Dodge,
        NumberOfModes
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
		s.activeMonster = this;
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

    public void TakeDamage( int dmg)
    {
        currentStats.HP -= dmg;
        //EFFECTS!!!!!

        //different effect for dead
    }

    //something needs to use this
    public static void ResolveMonsterConflict(Monster att, Monster def)
    {
        def.TakeDamage(CalcDamage(att, def));

        if (def.IsAlive)
            att.TakeDamage(CalcDamage(def, att));
    }

    public static int CalcDamage(Monster att, Monster def)
    {
        int dmgDone = att.currentStats.Att - def.currentStats.Def;
        dmgDone = Mathf.Max(1, dmgDone);
        return dmgDone;
    }

    public string DebugValues()
    {
        return myEntry.name + " in mode " + CurrentMode.ToString();
    }
}
