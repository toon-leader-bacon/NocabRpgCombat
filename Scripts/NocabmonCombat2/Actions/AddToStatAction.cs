using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToStatAction : MonoBehaviour, IAction
{
  public AddToStatAction(int amountToAdd_, NocabmonStat targetStat_)
  {
    amountToAdd = amountToAdd_;
    targetStat = targetStat_;
  }


  public int amountToAdd;
  public NocabmonStat targetStat;

  public void activate(INocabmon target)
  {
    switch (this.targetStat)
    {
      case NocabmonStat.HP: { target.stats.HP_Value.addToCurrent(this.amountToAdd); return; }

      case NocabmonStat.Attack: { target.stats.Attack_Value.addToCurrent(this.amountToAdd); return; }
      case NocabmonStat.Defense: { target.stats.Defense_Value.addToCurrent(this.amountToAdd); return; }
      case NocabmonStat.SpecialAttack: { target.stats.SpecialAttack_Value.addToCurrent(this.amountToAdd); return; }
      case NocabmonStat.SpecialDefense: { target.stats.SpecialDefense_Value.addToCurrent(this.amountToAdd); return; }

      case NocabmonStat.Speed: { target.stats.Speed_Value.addToCurrent(this.amountToAdd); return; }

      default: return; // TODO: Error logging here
    }

  }

  public DamageType GetDamageType()
  {
    return DamageType.Bludgeon;
  }
}
