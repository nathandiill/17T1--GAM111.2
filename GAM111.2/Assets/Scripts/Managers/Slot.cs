using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour 
{
	//these are fields
	public MasterClass activeClass;
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
			return activeClass == null;
		}
	}

    public bool HasMonster
    {
        get
        {
            return activeClass != null;
        }
    }

    public void Init(Player p, int i)
    {
        owner = p;
        index = i;
        activeClass = null;
    }

    public void Deactivate()
    {
        if (activeClass != null)
        {
            activeClass.GoIdle();
        }
    }

    public void Activate()
    {
        if (activeClass != null)
        {
            activeClass.GoActive();
        }
    }

    void OnMouseUpAsButton()
    {
        owner.SetSelectedClass(this);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
        }
    }
}
