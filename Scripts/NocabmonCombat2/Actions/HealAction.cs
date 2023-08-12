using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealAction : MonoBehaviour, IActionHeal
{
  public HealAction(uint damageToHeal_)
  {
    damageToHeal = damageToHeal_;
  }

  public uint damageToHeal;

  public void activate(INocabmon target)
  {
    target.stats.HP_Value.addToCurrent((int)amountToHeal(), breakMax: false);
  }

  public DamageType GetDamageType()
  {
    return DamageType.Heal;
  }

  public uint amountToHeal()
  {
    return this.damageToHeal;
  }
}
