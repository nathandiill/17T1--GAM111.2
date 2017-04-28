using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoTheRound : BaseCommand {

    public override void Start()
    { 
        var activePlayer = TurnManager.inst.ActivePlayer;
        var otherPlayer = TurnManager.inst.OtherPlayer;

        //for each slot 
        //  if there is a monster there then resolve
        //      if enemy has monster there then monster monster resolve
        //      if no enemy attack player
        for (int i = 0; i < activePlayer.myField.Length; i++)
        {
            var slot = activePlayer.myField[i];
            var otherSlot = otherPlayer.myField[activePlayer.myField.Length - 1 - i];
           
            var cmd = new SlotAttackCommand(slot, otherSlot);

            //add it to the queue...
            //  this makes it in reverse, don't care
            TurnManager.inst.InsertCmdAfter(cmd, this);
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
