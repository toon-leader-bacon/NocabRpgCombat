using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MultiAction : MonoBehaviour, IAction
{
  public MultiAction(List<IAction> actions_)
  {
    actions = actions_;
  }

  public List<IAction> actions;

  public void activate(INocabmon target) {
    foreach(IAction action in actions) {
      target.ApplyAction(action);
    }
  }

  public DamageType GetDamageType() {
    return DamageType.None;
  }
}