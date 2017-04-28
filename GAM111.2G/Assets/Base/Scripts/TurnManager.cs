using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This is the guts of what makes the players change turns and handle the attack buttons
*/
public class TurnManager : MonoBehaviour {

	public Player playerA, playerB;
    private Player activePlayer, otherPlayer;

    public Player ActivePlayer
    {
        get
        {
            return activePlayer;
        }
    }
    public Player OtherPlayer
    {
        get
        {
            return otherPlayer;
        }
    }

    private bool hasGameBegun = false;

    public UnityEngine.UI.Button endTurnButton;

    LinkedList<BaseCommand> cmdList = new LinkedList<BaseCommand>();

    public void InsertCmdAfter(BaseCommand cmdToInsert, BaseCommand afterThis)
    {
        cmdList.AddAfter(cmdList.Find(afterThis), cmdToInsert);
    }

    public static TurnManager inst;

    void Awake()
    {
        inst = this;
    }

	// Use this for initialization
	void Start () 
    {
        activePlayer = playerA;
        otherPlayer = playerB;
	}

    public void BeginGame()
    {
        //HACK this is bad
        otherPlayer.HP = 20;
        activePlayer.HP = 20;

        otherPlayer.GoInactive();
        activePlayer.GoActive();
        
        hasGameBegun = true;
    }

    public void OnEndTurnButtonHit()
    {
        if (!hasGameBegun || cmdList.Count > 0)
            return;

        //process active player things
		GenerateAttackCommandList();
    }

    void Update()
    {
        endTurnButton.interactable = cmdList.Count == 0;
        
        if (cmdList.Count > 0)
        {
            //
            var frontItem = cmdList.First.Value;

            if (!frontItem.HasStarted)
            {
                frontItem.Start();
                frontItem.HasStarted = true;
            }

            frontItem.Update();

            if (frontItem.IsFinished())
            {
                //this is so we COULD add things in front of this during update or state
                //  and still be finished
                cmdList.Remove(frontItem);
            }
        }
    }

    public void SwitchPlayers()
    {
        var tmp = activePlayer;
        activePlayer = otherPlayer;
        otherPlayer = tmp;

        otherPlayer.GoInactive();
        activePlayer.GoActive();
        activePlayer.SetSelectedMonster(null);
    }

    //this is now instant we want this to take time, how can we do this?
	public void GenerateAttackCommandList()
    {
        cmdList.AddLast(new StartOfRound());
        cmdList.AddLast(new DoTheRound());
        cmdList.AddLast(new EndOfRoundCommand());
    }

    public bool AreThereAnyMonstersAlive()
    {
        return playerA.HasAnyMonstersAlive() || playerB.HasAnyMonstersAlive();
    }

    public void GoToDraw()
    {
        //todo needs to chamge state
        Debug.Log("Its a draw");
    }
}
