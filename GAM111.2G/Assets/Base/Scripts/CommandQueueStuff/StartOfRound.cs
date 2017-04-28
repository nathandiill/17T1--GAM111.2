using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartOfRound : BaseCommand {
    #region implemented abstract members of BaseCommand

    public override void Start()
    {   
        //detect draws
        //if both fields are empty
        if (!TurnManager.inst.AreThereAnyMonstersAlive())
        {
            TurnManager.inst.GoToDraw();
        }
    }

    public override void Update()
    {
    }

    public override bool IsFinished()
    {
        return true;
    }

    #endregion


}
