using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//to assign random monsters to both players slots and init them
public class SetupMonsters : MonoBehaviour 
{
	public GameObject[] monsterPres;

	public Player[] players;


	public void Generate()
	{
		//for all players
		for (int i = 0; i < players.Length; i++)
		{
			//for all slots
			for (int j = 0; j < players[i].myField.Length; j++) 
			{
				//if there is a monster there, KILL IT
				if (players[i].myField[j].activeMonster != null)
				{
					Destroy(players[i].myField[j].activeMonster.gameObject);
				}
                
				//random between 0 - monpre.len
				var chosenMonsterPre = monsterPres[Random.Range(0, monsterPres.Length)];

				GameObject chosenMonster = Instantiate(chosenMonsterPre, players[i].myField[j].transform, false);

				//but wait there's more
				Monster newMonster = chosenMonster.GetComponent<Monster>();
				newMonster.Init(players[i].myField[j]);
			}
		}
	}

    public void StartGame()
    {
        //tell turn manager to start
        //TODO, this should only happen if there is actually monsters generated
        gameObject.GetComponent<GameStateManager>().BeginGame();
    }
}
