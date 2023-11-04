using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndeadNocabmon : INocabmon
{
    public UndeadNocabmon(int maxHitPoints, List<IAction> possibleActions)
    {
        this.Stats.HP_Value = new StatusValue(maxHitPoints, maxHitPoints);
        base.PossibleActions = possibleActions;
    }

    protected override IAction? SelectActionDefaultBehaviour()
    {
        // TODO: Think of better strategies than picking a random attack
        NocabRNG rng = NocabRNG.defaultRNG;
        return rng.randomElem<IAction>(PossibleActions);
    }

    public override void ApplyAction(IAction action)
    {
        if (action is IActionHeal)
        {
            this.applyAction(action as IActionHeal);
        }
        else
        {
            action.activate(this);
        }
    }

    void applyAction(IActionHeal healAction)
    {
        // Don't call healAction.activate(...) because undead creatures are special
        this.Stats.HP_Value.subtractCurrent((int)healAction.amountToHeal());
    }

    public override bool IsDead()
    {
        // Note, this creature is called "undead" but the INocabmon interface
        // stimulates that this function checks if the creature has no HP remaining.
        // Perhapses the function should be renamed to "isDefeated"?
        return this.Stats.HP_Value.Current <= 0;
    }
}
