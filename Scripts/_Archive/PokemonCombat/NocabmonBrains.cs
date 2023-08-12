using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class NocabmonBrains
{


  public static HashSet<NocabmonMono> findAllEnemyIds(
      CombatIdentifier friendlyID, CombatData combatData) {
    /**
     * @brief Given the team id for a friendly team, and some CombatData,
     * this function returns a collection of every single Nocabmon that is NOT
     * on the provided team.
     * Put another way: Get all the enemy nocabMon units in the Combat Data.
     *
     * @param friendlyID A CombatIdentifier to note who is friend (and who is foe).
     * The TeamID field SHOULD be set and valid. If the TeamID field is NOT set
     * or invalid, then all Nocabmon units from every team will be extracted from
     * the combat data.
     * If that's the case, it's reccomended to use the
     * CombatData.getAllUnitIDs() function instead
     *
     * @param combatData The data to look up mobs and teams from.
     *
     * @returns a Collection of every Nocabmon in the combat data that is NOT on
     * the provided team.
     *
     * @NOTE: Weird things may happen if a mob is on multiple teams.
     */
    HashSet<string> allEnemyIds = new HashSet<string>();

    foreach (string enemyTeamId in combatData.getEnemyTeamIDs(friendlyID.TeamID)) {
      allEnemyIds.UnionWith(combatData.getTeam(enemyTeamId));
    }

    HashSet<NocabmonMono> result = new HashSet<NocabmonMono>();
    foreach (string enemyId in allEnemyIds) {
      result.Add(combatData.getMob(enemyId));
    }

    return result;
  }


  public static CombatIdentifier findRandom(
      IList<NocabmonMono> possibleTargets, NocabRNG rng) {
    /**
     * Returns a random mob from the provided mobs. This is a O(1) operation.
     *
     *
     * TODO: Consider a findRandom(...) function that picks a random team, then
     * using that team, pulls a random mob. The issue is that "what if the
     * randomly selected team has no mobs in it?".
     *
     * Pulling a team, then a mob would be slightly more preformant in my estimation,
     * but not by much.
     */
    return rng.randomElem<NocabmonMono>(possibleTargets).CombatID;
  }

  public static CombatIdentifier findRandom(
      HashSet<NocabmonMono> possibleTargets, NocabRNG rng) {
    /**
     * Returns a random mob from the provided mobs. This is a O(n) operation.
     * It's reccomended to use the List variant of this function instead.
     */
    return rng.randomElem_Set<NocabmonMono>(possibleTargets).CombatID;
  }

  public static CombatIdentifier findRandom(
      IEnumerable<NocabmonMono> possibleTargets, NocabRNG rng) {
    /**
     * Returns a random mob from the provided mobs. This is a O(n) operation.
     * It's reccomended to use the List variant of this function instead. Even
     * the HashSet variant is slightly more preformant than this one.
     */
    return rng.randomElem_IEnumerator<NocabmonMono>(possibleTargets.GetEnumerator()).CombatID;
  }



  public static CombatIdentifier findWeakest(IEnumerable<NocabmonMono> possibleTargets) {
    /**
     * Returns the NocabmonMon with the lowest HP that is still alive.
     * NOTE: If all the mons are dead, then a random dead mon will be returned.
     */
    return findLeast(possibleTargets, remainingHpAndAlive);
  }

  private static int remainingHpAndAlive(NocabmonMono mon) {
    // If the mon is dead, return a large number. Otherwise, return the
    // amount of HP this mon still has
    if (mon.isDead()) {
      // If the mon is dead,
      return int.MaxValue;
    }
    return mon.nocabMonData.HP_.Current;
  }

  public static CombatIdentifier findFirst(
      IEnumerable<NocabmonMono> possibleTargets,
      Func<NocabmonMono, bool> filterFunction) {
    /**
     * @brief iterate through provided Mons and return the first UUID that
     * passes the provided filter function. In other words, this function will return
     * the first unit that causes the filter function to return true.
     * If there are multiple of such targets that cause the filter to return true,
     * the first is returned.
     *
     * @param possibleTargets The collection of mobs to consider/ evaluate.
     * @param filterFunction the function used to determine if an enemy should be returned.
     * This function should accept in a NocabmonMono and return a boolean.
     */
    foreach (NocabmonMono enemy in possibleTargets) {
      if (filterFunction(enemy)) {
        return enemy.CombatID;
      }
    }
    throw new System.Exception("Can not find suitable target.");
  }

  public static CombatIdentifier findMost(
      IEnumerable<NocabmonMono> possibleTargets,
      Func<NocabmonMono, int> evaluator) {
    /**
     * @brief iterate through all provided mons and return the uuid of the mon that,
     * when provided to the evaluator function, produced the LARGEST value.
     * If there is a tie, the returned mon is the earliest of the bunch in the list.
     *
     * @param possibleTargets The Mons to sift through
     * @param evaluator the function used to measure the enemies. This function
     * should take in a NocabmonMono and return a value (may be negative) to score it.
     */
    // Find the value enemy that produces the LARGEST value, when passed through the evaluator
    return _findExtreme(
      possibleTargets,
      evaluator,

      // Challenger only wins if it is LARGER than the previous best
      (int challenger, int previousBest) => { return challenger > previousBest; }
    );
  }

  public static CombatIdentifier findLeast(
      IEnumerable<NocabmonMono> possibleTargets,
      Func<NocabmonMono, int> evaluator) {
    /**
     * @brief iterate through all provided mons and return the uuid of the mon that,
     * when provided to the evaluator function, produced the SMALLEST value.
     * If there is a tie, the returned mon is the earliest of the bunch in the list.
     *
     * @param possibleTargets The Mons to sift through
     * @param evaluator the function used to measure the enemies. This function
     * should take in a NocabmonMono and return a value (may be negative) to score it.
     */
    // Find the value enemy that produces the SMALLEST value, when passed through the evaluator
    return _findExtreme(
      possibleTargets,
      evaluator,

      // Challenger only wins if it is SMALLER than the previous best
      (int challenger, int previousBest) => { return challenger < previousBest; }
    );
  }


  private static CombatIdentifier _findExtreme(
      IEnumerable<NocabmonMono> possibleTargets,
      Func<NocabmonMono, int> evaluator,
      Func<int, int, bool> XThan) {
    /**
     * @brief Internal helper function used to deduplicate some code.
     * Sift through all enemies, use the provided evaluator to score each one. Then use the
     * XThan function to compare scores. Usually XThan is > or < functions.
     *
     * @param XThan The first argument is the score of the challenging mon, the
     * second argument is the score of the current best mon. Return true when the
     * challenger is better than the current best.
     */
    IEnumerator<NocabmonMono> enumerator = possibleTargets.GetEnumerator();

    if (!enumerator.MoveNext()) {
      // If provided an empty collection
      string errorMsg = "Provided an empty collection of possible targets!";
      throw new ArgumentException(errorMsg);
    }

    // The first in the collection is (by definition) the best we've seen so far
    CombatIdentifier uuidOfBest = enumerator.Current.CombatID;
    int bestSoFar = evaluator(enumerator.Current);

    while (enumerator.MoveNext()) {
      NocabmonMono challengerMon = enumerator.Current;
      int challengerValue = evaluator(challengerMon);

      // Compare the value of current enemy to the previous best.
      // Basically, either (targetValue < bestSoFar) vs. (targetValue > bestSoFar)
      if (XThan(challengerValue, bestSoFar)) {
        bestSoFar = challengerValue;
        uuidOfBest = challengerMon.CombatID;
      }
    }

    return uuidOfBest;
  }

}
