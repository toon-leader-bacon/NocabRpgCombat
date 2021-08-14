using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class NocabmonMono : MonoBehaviour
{
  /**
   * A Nocabmon is a custom rolled Pokemon Monobehaviour. Current emphasis
   * is on geting a simple thing to work, and optimizing it later.
   */

  // TODO: Make this not public, but externally read only
  public Nocabmon nocabMonData;

  private CombatIdentifier id;
  public CombatIdentifier CombatID { get { return this.id; } }

  public void initNocab(Nocabmon newData, CombatIdentifier newID)
  {
    /**
     * A custom made initialization function. Typically this SHOULD
     * be called when creating a new instance of the NocabmonMono obj.
     */
    this.swapData(newData);
    this.setCombatIdentifier(newID);
  }

  public void setCombatIdentifier(CombatIdentifier newID)
  {
    this.id = newID;
  }

  public Nocabmon swapData(Nocabmon newData)
  {
    Nocabmon result = this.nocabMonData;
    this.nocabMonData = newData;
    return result;
  }

  public Action runTurn(CombatData data)
  {
    // Lookup who the enemy is
    // Pick a move to use vs the enemy
    // return that action

    Action result = new Action();
    result.isSpecial = false; // False for now always

    HashSet<NocabmonMono> allEnemies = NocabmonBrains.findAllEnemyIds(this.CombatID, data);
    result.combatId = NocabmonBrains.findRandom(allEnemies, NocabRNG.defaultRNG);

    result.damage = this.nocabMonData.Attack_;
    return result;
  }

  public void applyActionOnMe(Action action)
  {
    // Take the provided action, and execute it vs this mon

    if (!action.isSpecial)
    {
      // If the action is NOT special (IE mundane)
      // TODO: Implement this
    }

    // TODO: some pipeline here

    this.subtractHP(action.damage);
  }

  public bool isDead() {
    Debug.Log("Current HP: " + this.nocabMonData.HP_.Current);
    return this.nocabMonData.HP_ <= 0;
  }

  private bool subtractHP(int processedDmg)
  {
    /**
     * WARNING! This method changes the underlying HP value of the Nocabmon data
     * container. Typically, you don't want to call this function directly. Instead
     * please consider using the applyActionOnMe(...) function.
     *
     * To heal this mon, provide this function a negative number.
     * A positive number will damage this mon.
     *
     * @param processedDmg The true damage to subtract to the data model.
     * @returns True if the new HP is below 0, false otherwise. True => this damage
     * hit has killed the mon.
     */

    this.nocabMonData.HP_.subtractCurrent(processedDmg);
    return !this.nocabMonData.HP_.isPositive;
  }

}

public class Nocabmon
{
  /** A data model to represent a Nocabmon */
  public StatusValue HP_;
  public StatusValue Energy_;

  // TODO: Make single skills like this some kind of class? With good typing?
  public int Attack_;
  public int Defense_;

  public Nocabmon(int maxHP)
  {
    this.HP_ = new StatusValue(maxHP, maxHP);

    // Todo: accept in a better max energy?
    this.Energy_ = new StatusValue(100, 0);

    this.Attack_ = 10;
    this.Defense_ = 5;
  }
}
