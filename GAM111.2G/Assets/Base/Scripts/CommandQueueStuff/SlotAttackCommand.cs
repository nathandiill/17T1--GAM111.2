using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotAttackCommand : BaseCommand 
{
    private Slot attackerSlot, defenderSlot;

    private float counter = 0, delay = 0.3f;


    public SlotAttackCommand(Slot aSlot, Slot dSlot)
    {
        attackerSlot = aSlot;
        defenderSlot = dSlot; 
    }

    public override void Start()
    {   
        if (attackerSlot.HasMonster && attackerSlot.activeMonster.IsAlive)
        {
            var curMonster = attackerSlot.activeMonster;
            var otherMonster = defenderSlot.activeMonster;

            if (otherMonster != null && otherMonster.IsAlive)
            {
                Debug.Log(curMonster.DebugValues() + " fights " + otherMonster.DebugValues());
                Monster.ResolveMonsterConflict(curMonster, otherMonster);
            }
            else
            {
                defenderSlot.owner.HandleMonsterAttack(curMonster);
            }
        }
    }

    public override void Update()
    {
        counter += Time.deltaTime;
    }

    public override bool IsFinished()
    {
        return attackerSlot.activeMonster.IsDead || counter > delay;
    }
}
