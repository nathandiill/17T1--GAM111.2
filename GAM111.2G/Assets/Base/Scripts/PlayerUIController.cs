using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

/*
    Controller and view updater for the player's UI.

    todo: needs to show more stats and who is the active player, turn count etc.
*/
public class PlayerUIController : MonoBehaviour 
{
	public Player targetPlayer;

    public Text slotText, monsterNameText;

    public Button mode1, mode2, mode3;
    public Text mode1ButtonText, mode2ButtonText, mode3ButtonText;
    
    public void ClearAll()
    {
        slotText.text = string.Empty;
        monsterNameText.text = string.Empty;

        mode1.interactable = false;
        mode2.interactable = false;
        mode3.interactable = false;
        mode1ButtonText.text = Monster.Mode.Attack.ToString();
        mode2ButtonText.text = Monster.Mode.Defend.ToString();
        mode3ButtonText.text = Monster.Mode.Dodge.ToString();
    }

	public void UpdateFromSlot(Slot s)
    {
        ClearAll();
        
		if (s == null || s.owner != targetPlayer)
            return;

        slotText.text = s.index.ToString();

        if (s.HasMonster)
        {
            UpdateMonsterButtons();
        }
    }

	#region buttoncallbacks
    public void Mode1Clicked()
    {
        targetPlayer.selectedMonster.CurrentMode = Monster.Mode.Attack;
        UpdateMonsterButtons();
    }
    public void Mode2Clicked()
    {
        targetPlayer.selectedMonster.CurrentMode = Monster.Mode.Defend;
        UpdateMonsterButtons();
    }
    public void Mode3Clicked()
    {
        targetPlayer.selectedMonster.CurrentMode = Monster.Mode.Dodge;
        UpdateMonsterButtons();
    }
	#endregion

    public void UpdateMonsterButtons()
    {
        monsterNameText.text = targetPlayer.selectedMonster.myEntry.name;

		if (targetPlayer.isAIControlled)
			return;

        mode1.interactable = targetPlayer.selectedMonster.CurrentMode != Monster.Mode.Attack;
        mode2.interactable = targetPlayer.selectedMonster.CurrentMode != Monster.Mode.Defend;
        mode3.interactable = targetPlayer.selectedMonster.CurrentMode != Monster.Mode.Dodge;
    }
}
