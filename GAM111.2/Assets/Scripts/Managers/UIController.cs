using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
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
            mode1ButtonText.text = MasterClass.Mode.Attack.ToString();
            mode2ButtonText.text = MasterClass.Mode.Defend.ToString();
            mode3ButtonText.text = MasterClass.Mode.Dodge.ToString();
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

        public void Mode1Clicked()
        {
            targetPlayer.selectedClass.CurrentMode = MasterClass.Mode.Attack;
            UpdateMonsterButtons();
        }
        public void Mode2Clicked()
        {
            targetPlayer.selectedClass.CurrentMode = MasterClass.Mode.Defend;
            UpdateMonsterButtons();
        }
        public void Mode3Clicked()
        {
            targetPlayer.selectedClass.CurrentMode = MasterClass.Mode.Dodge;
            UpdateMonsterButtons();
        }

        public void UpdateMonsterButtons()
        {
            monsterNameText.text = targetPlayer.selectedClass.myEntry.name;

            mode1.interactable = targetPlayer.selectedClass.CurrentMode != MasterClass.Mode.Attack;
            mode2.interactable = targetPlayer.selectedClass.CurrentMode != MasterClass.Mode.Defend;
            mode3.interactable = targetPlayer.selectedClass.CurrentMode != MasterClass.Mode.Dodge;
        }
    }
