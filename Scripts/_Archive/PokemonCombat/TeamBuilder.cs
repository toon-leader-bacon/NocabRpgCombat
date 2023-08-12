using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamBuilder
{

  private static NocabRNG rng = NocabRNG.defaultRNG;

  public List<NocabmonMono> buildCloneTeam(
    string teamName, uint size, NocabmonMono toClone, Nocabmon_old data, string monNamePrefix = "")
  {
    /**
     * Produces a Team of NocabMon monobehaviors that are all on the same team. 
     * Each of these mons will be instantiated clones from the provided prefab. 
     * The only difference between them is they will have a new CombatIdentifier 
     * provided to them to mark what team they're on. All will be on the same team.
     * 
     * Each mon will also have a GUID (8 bytes) to identify themselves.
     */
    if (size <= 0)
    {
      Debug.LogWarning($"Warning! Building team with {size} number of mons, " +
                        "which is <= 0. Replacing this with the value 1. A " +
                        "combat team MUST have at least 1 mon on it.");
      size = 1;
    }

    List<NocabmonMono> result = new List<NocabmonMono>();
    for (int i = 0; i < size; i++)
    {
      NocabmonMono newMon = GameObject.Instantiate<NocabmonMono>(toClone);
      string monName = monNamePrefix + rng.generateUUID(8);
      newMon.initNocab(data, new CombatIdentifier(teamName, monName));
      // newMon.setCombatIdentifier(new CombatIdentifier(teamName, monName));
      result.Add(newMon);
    }

    return result;
  }

}
