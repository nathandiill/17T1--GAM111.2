using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Represents a single location for a monster to be in. A player will have many of these,
        they make up the player's field.
*/
public class Slot : MonoBehaviour 
{
	//these are fields
	public Monster activeMonster;
	public Player owner;
	//public Slot[] targetableSlots;
	public int index;

    private bool isSelected = false;
    public bool IsSelected
    {
        get
        {
            return isSelected;
        }
        set
        {
            isSelected = value;
        }
    }


	//this is a property
	public bool IsAvailable 
	{
		get 
		{
			return activeMonster == null;
		}
	}

    public bool HasMonster
    {
        get
        {
            return activeMonster != null;
        }
    }

    public void Init(Player p, int i)
    {
        owner = p;
        index = i;
        activeMonster = null;
    }

    public void Deactivate()
    {
        if (activeMonster != null)
        {
            activeMonster.GoIdle();
        }
    }

    public void Activate()
    {
        if (activeMonster != null)
        {
            activeMonster.GoActive();
        }
    }

    //we have a collider on us so we can be clicked on
    void OnMouseUpAsButton()
    {
		if(!owner.isAIControlled)
		{
			SetThisAsSelected ();
		}
    }

	[ContextMenu("SetThisAsSelected")]
	public void SetThisAsSelected()
	{
		owner.SetSelectedMonster(this);
	}
}
