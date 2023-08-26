using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NocabmonFactory : MonoBehaviour
{

  public Nocabmon buildNocabmon()
  {
    return new Nocabmon(maxHitPoints: 10, possibleActions: new List<IAction> { new AttackAction(3) }, team: false);
  }

  public INocabmon buildUndead()
  {
    return new UndeadNocabmon(maxHitPoints: 8, possibleActions: new List<IAction> { new AttackAction(3) }, team: false);
  }
}
