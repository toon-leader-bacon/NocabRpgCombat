using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class INocabmon : MonoBehaviour
{
  public NocabmonStatCollection stats;

  public bool Team; // Player is always team true


  public List<IAction> PossibleActions;

  public abstract IAction selectAction();

  public abstract void applyAction(IAction action);

  public abstract bool isDead();

}
