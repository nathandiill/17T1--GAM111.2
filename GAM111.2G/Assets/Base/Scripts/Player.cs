using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Represents a player in our game. Player's are the root of the data structure, they
    have a field made of slots which may or may not have monsters. Further a player must be 
    killed or both players to have no monsters for there to be a winner.
*/
public class Player : MonoBehaviour {

	//does this actually go here?
	//	UI perhaps
	public Monster selectedMonster;
    PlayerUIController _uiController;
    public PlayerUIController UIController
    {
        get
        {
            if(_uiController == null)
                _uiController = FindObjectOfType<PlayerUIController>();

            return _uiController;
        }
    }


    public int HP { get; set; }

	public bool isAIControlled = false;

	//list of cards available

	//mana or AP here?

	public Slot[] myField;

    public bool IsAlive
    {
        get
        {
            return HP > 0;
        }
    }

    public bool IsDead
    {
        get
        {
            return HP <= 0;
        }
    }

	// Use this for initialization
	void Start () 
    {
        myField = gameObject.GetComponentsInChildren<Slot>();

        for (int i = 0; i < myField.Length; i++)
        {
            myField[i].Init(this, i);
        }
	}

    public void GoInactive()
    {
        for (int i = 0; i < myField.Length; i++)
        {
            myField[i].Deactivate();
        }
    }

    public void GoActive()
    {
        UIController.targetPlayer = this;
        UIController.ClearAll();

        for (int i = 0; i < myField.Length; i++)
        {
            myField[i].Activate();
        }
    }

    public void HandleMonsterAttack(Monster mon)
    {
        HP -= mon.currentStats.Att;

        if (IsDead)
        {
            Debug.Log("Effects here, we dead");
        }
    }

    public void SetSelectedMonster(Slot s)
    {
        if(s == null || System.Array.IndexOf(myField,s) != -1)
        {
            if (s != null && s.HasMonster)
                selectedMonster = s.activeMonster;

            UIController.UpdateFromSlot(s);
        }
    }

    public bool HasAnyMonstersAlive()
    {
        for (int i = 0; i < myField.Length; i++)
        {
            if (myField[i].HasMonster && myField[i].activeMonster.IsAlive)
                return true;
        }

        //the only way to get here is with no monsters
        return false;
    }
}
