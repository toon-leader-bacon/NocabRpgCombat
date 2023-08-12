using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NocabmonFactory : MonoBehaviour
{
  Nocabmon buildNocabmon()
  {
    return new Nocabmon(maxHitPoints: 10, possibleActions: new List<IAction> { new AttackAction(3) }, team: false);
  }
}
