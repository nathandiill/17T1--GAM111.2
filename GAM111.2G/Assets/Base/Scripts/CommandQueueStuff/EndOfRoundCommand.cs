using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfRoundCommand : BaseCommand {
    public override void Start()
    {   
        //switch to next player
        //here we need to check for dead players and award a winner
        if (TurnManager.inst.OtherPlayer.IsDead)
        {
            TurnManager.inst.GetComponent<GameStateManager>().EndOfGame();
        }
        else
        {
            TurnManager.inst.SwitchPlayers();
        }
    }

    public override void Update()
    {
    }

    public override bool IsFinished()
    {
        return true;
    }
}
