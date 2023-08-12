using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAction : MonoBehaviour, IAction
{
  public AttackAction(int damageToDeal_)
  {
    damageToDeal = damageToDeal_;
  }


  public int damageToDeal;

  public void activate(INocabmon target)
  {
    target.stats.HP_Value.subtractCurrent(this.damageToDeal);
  }

  public DamageType GetDamageType() {
    return DamageType.Bludgeon;
  }
}
