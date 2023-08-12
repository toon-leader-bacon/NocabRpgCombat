using System.Collections.ObjectModel;
using System.Net;
using System.Globalization;
using System.Runtime.InteropServices.ComTypes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CombatData
{
  /**
   * @brief CombatData contains all the information and data needed in a typical
   * battle sequence. A simple way to think about this class is as an organized
   * list of combatants.
   * Use the CombatData to quickly look up teams, enemies, friends and other Mons.
   * Each Mon will probably have its own data representation class but that has
   * not been implimented as of June 2021.
   */

  // A mapping of UnitID to the Monobehaviour that represents it.
  private Dictionary<string, NocabmonMono> monIdToMon = new Dictionary<string, NocabmonMono>();


  // A mapping of TeamID to Set<UnitID>
  private DictionarySet<string, string> teamsToMons = new DictionarySet<string, string>();
  public CombatData() { }


  /**
   * @brief Adds or update a single NocabmonMono to the CombatData.
   * If the provided NocabMob has a never-before-seen UnitID, it wll
   * be added. Otherwise, the object reference and "team" of the
   * provided NocabmonMon will be updated.
   *
   * In summary, the CombatID.UnitID is the hash function here.
   */
  public void addMob(NocabmonMono newMobToAdd)
  {
    string UnitID = newMobToAdd.CombatID.UnitID;
    if (this.containsMob(UnitID))
    {
      this.removeMob(UnitID);
    }

    this.monIdToMon.Add(newMobToAdd.CombatID.UnitID, newMobToAdd);
    this.addToTeam(newMobToAdd);
  }

  /**
   * @brief Adds or update a list of NocabmonMono to the CombatData.
   * See addMob(NocabmonMono newMobToAdd) documentation.
   * If the provided NocabMob has a never-before-seen UnitID, it wll
   * be added. Otherwise, the object reference and "team" of the
   * provided NocabmonMon will be updated.
   */
  public void addMobs(IEnumerable<NocabmonMono> mobs)
  {
    foreach (NocabmonMono mon in mobs)
    {
      this.addMob(mon);
    }
  }

  public HashSet<string> getTeam(string teamID) {
    if ( ! this.containsTeam(teamID)) {
      // TODO Do something bad here. Maybe return empty set?
      string warning = "Attempting to get an unknown team from the CombatData. " +
      "Offending TeamID: " + teamID;
      Debug.LogError(warning);
      return new HashSet<string>();
    }
    return new HashSet<string>(this.teamsToMons.safeGet(teamID));
  }

  public NocabmonMono getMob(string UnitID) {
    /**
     * @brief Given a valid unit id, this func returns the NocabmonMono.
     * If the provided UnitID is invalid (IE: not contained within this CombatDat)
     * then an ArgumentException will be thrown.
     */
    if ( ! this.containsMob(UnitID)) {
      // TODO Do something bad here. Maybe some default test mob?
      string warning = "Attempting to get an unknown mob from the CombatData. " +
      "Offending UnitID: " + UnitID;
      Debug.LogError(warning);
      throw new ArgumentException(warning);
    }
    return this.monIdToMon[UnitID];
  }

  public HashSet<string> getAllUnitIDs() {
    HashSet<string> result = new HashSet<string>(monIdToMon.Keys);
    return result;
  }

  public List<string> getAllUnitIds_List() {
    return new List<string>(monIdToMon.Keys);
  }

  public HashSet<string> getEnemyTeamIDs(HashSet<string> friendlyTeams) {
    /**
     * @brief returns the TeamIDs that are in this CombatData, but not
     * in the provided filter of friendly teams.
     *
     */
    HashSet<string> teamIdSet = new HashSet<string>(this.teamsToMons.Keys);
    // Remove all friendly teams from copy of internal list of teams
    teamIdSet.RemoveWhere( teamID => friendlyTeams.Contains(teamID) );
    return teamIdSet;
  }

  public HashSet<string> getEnemyTeamIDs(string friendlyTeamID) {
    HashSet<string> teamIds = new HashSet<string>(this.teamsToMons.Keys);
    teamIds.Remove(friendlyTeamID);
    return teamIds;
  }

  /**
   * @brief, returns true if the provided UnitID is present in this CombatData.
   */
  public bool containsMob(string UnitID)
  {
    return this.monIdToMon.ContainsKey(UnitID);
  }
  public bool containsMob(CombatIdentifier identifier)
  {
    return this.containsMob(identifier.UnitID);
  }
  public bool containsMob(NocabmonMono mono) {
      return this.containsMob(mono.CombatID.UnitID);
  }

  public bool containsTeam(string TeamID) {
    return this.teamsToMons.ContainsKey(TeamID);
  }


  /**
   * @brief Removes the mob referenced by the provided UnitID from this
   * CombatData. If the provided UnitID is not present, then this function
   * is a no-op.
   */
  public void removeMob(string UnitID)
  {
    if (!this.containsMob(UnitID))
    {
      return;
    }

    // Remove from all teams first
    string teamID = this.monIdToMon[UnitID].CombatID.TeamID;
    this.teamsToMons.Remove(teamID, UnitID);

    // Remove last reference to Unit
    this.monIdToMon.Remove(UnitID);
  }

  public void removeMob(CombatIdentifier identifier) {
    this.removeMob(identifier.UnitID);
  }
  public void removeMob(NocabmonMono mob) {
    this.removeMob(mob.CombatID.UnitID);
  }

  public void removeMobs(IEnumerable<CombatIdentifier> ids) {
    foreach(CombatIdentifier id in ids) {
      this.removeMob(id.UnitID);
    }
  }
  public void removeMobs(IEnumerable<NocabmonMono> mobs) {
    foreach(NocabmonMono mob in mobs) {
      this.removeMob(mob.CombatID.UnitID);
    }
  }




  private void addToTeam(NocabmonMono mobToAdd)
  {
    this.teamsToMons.Add(mobToAdd.CombatID.TeamID, mobToAdd.CombatID.UnitID);
  }


}
