using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleState
{
    // Every battle has a player mon
    public INocabmon playermon;

    // and an enemy monster
    public INocabmon enemymon;

    // True team always goes first
    // True = player
    public bool currentTurn;
}
