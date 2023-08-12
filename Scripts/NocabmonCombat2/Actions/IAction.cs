using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAction
{
  public void activate(INocabmon target);

  public DamageType GetDamageType(); // TODO: Consider removing this
  
}
