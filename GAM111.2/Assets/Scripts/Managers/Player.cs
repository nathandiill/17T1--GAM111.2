using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour {

	//does this actually go here?
	//	UI perhaps
	public MasterClass selectedClass;
    UIController _uiController;
    public UIController UIController
    {
        get
        {
            if(_uiController == null)
                _uiController = FindObjectOfType<UIController>();

            return _uiController;
        }
    }


    public int HP { get; set; }

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

    public void HandleMonsterAttack(MasterClass mon)
    {
        HP -= mon.currentStats.Att;

        if (IsDead)
        {
            Debug.Log("Effects here, we dead");
        }
    }

    public void SetSelectedClass(Slot s)
    {
        if(s == null || System.Array.IndexOf(myField,s) != -1)
        {
            if (s != null && s.HasMonster)
                selectedClass = s.activeClass;

            UIController.UpdateFromSlot(s);
        }
    }

    public bool HasAnyMonstersAlive()
    {
        for (int i = 0; i < myField.Length; i++)
        {
            if (myField[i].HasMonster && myField[i].activeClass.IsAlive)
                return true;
        }

        //the only way to get here is with no monsters
        return false;
    }
}
