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
  public Nocabmon(int maxHitPoints, List<IAction> possibleActions, bool team)
  {
    this.stats.HP_Value = new StatusValue(maxHitPoints, maxHitPoints);

    PossibleActions = possibleActions;

    Team = team;
  }

  public override IAction selectAction()
  {
    // TODO: Think of better strategies than picking a random attack
    NocabRNG rng = NocabRNG.defaultRNG;
    return rng.randomElem<IAction>(PossibleActions);
  }

  public override void applyAction(IAction action)
  {
    // NONE a Nocabmon may wish to intercept this typical dispatch and allow for 
    // unique custom behavior of the action. 

    action.activate(this);
  }

  public override bool isDead()
  {
    return this.stats.HP_Value.Current <= 0;
  }
}
