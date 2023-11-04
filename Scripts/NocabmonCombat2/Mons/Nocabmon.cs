using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * @brief A Nocabmon is an agent in a 1v1 turn based combat encounter
 * Each Nocabmon has HP, and a few Actions it can make.
 * Each action has a target (either self or the enemy)
 */
public class Nocabmon : INocabmon
{
    public Nocabmon(int maxHitPoints, List<IAction> possibleActions)
    {
        // TODO Remove this
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
        // NONE a Nocabmon may wish to intercept this typical dispatch and allow for
        // unique custom behavior of the action.

        action.activate(this);
    }

    public override bool IsDead()
    {
        return this.Stats.HP_Value.Current <= 0;
    }
}
