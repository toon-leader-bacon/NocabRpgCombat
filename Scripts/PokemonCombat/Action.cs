using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action {
    /**
     * An Action is a data structure that contains information describing
     * what a Nocabmon will do on its turn.
     */

    public CombatIdentifier combatId;

    public bool isSpecial = false;
    public int damage = 0;

    // Special actions run arbitrary code on the mon

    // Non-special (normal) actions just do a typical attack - defence thing
}
