using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAI : MonoBehaviour 
{
	public PlayerUIController pUICont;

	//why is this in update, this could be an event or called via turnman or other
	//	making this not update means that we can split this up over multiple frames easily
	void Update()
	{
		//is it the game state?

		// is the current player AI?
		if (pUICont.targetPlayer.isAIControlled) {


			//as a better ai 
			//	for each slot
			var field = pUICont.targetPlayer.myField;
			for (int i = 0; i < field.Length; i++) 
			{
				if (field[i].activeMonster.IsAlive)
				{
					field[i].SetThisAsSelected();

					Monster.Mode desiredMode = (Monster.Mode)Random.Range(0, (int)Monster.Mode.NumberOfModes);

					switch (desiredMode)
					{
						case Monster.Mode.Attack:
							pUICont.Mode1Clicked();
						break;
					case Monster.Mode.Defend:
						pUICont.Mode2Clicked();
						break;
					case Monster.Mode.Dodge:
						pUICont.Mode3Clicked();
						break;
						default:
							break;
					}
				}
			}
			// choose mode / attack type

			TurnManager.inst.OnEndTurnButtonHit ();
		}
	}
}
