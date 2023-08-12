using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndeadNocabmon : INocabmon
{


  IAction selectAction()
  {
    // TODO: Think of better strategies than picking a random attack
    NocabRNG rng = NocabRNG.defaultRNG;
    return rng.randomElem<IAction>(PossibleActions);
  }

  public override void applyAction(IAction action)
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
    this.stats.HP_Value.subtractCurrent((int)healAction.amountToHeal());
  }

  bool isDead()
  {
    // Note, this creature is called "undead" but the INocabmon interface
    // stimulates that this function checks if the creature has no HP remaining.
    // Perhapses the function should be renamed to "isDefeated"?
    return this.stats.HP_Value.Current <= 0;
  }
}
