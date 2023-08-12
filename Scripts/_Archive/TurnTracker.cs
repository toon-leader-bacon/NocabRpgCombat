using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTracker
{
  /**
   * A TurnTracker is an agent that is responsible for
   * deciding what Mon takes a turn and when. 
   */

  private List<string> ids;

  private int nextMonIndex;

  public TurnTracker(List<string> orderedIds)
  {
    if (orderedIds.Count <= 0) {
      throw new System.Exception(
        "TurnTracker MUST have at least one thing to track!");
    }
    this.ids = orderedIds;

    nextMonIndex = 0;
  }

  public string simple()
  {
    /**
     * Provides the next ID in the turn order. This WILL increment
     * the internal counter to the next turn. Once it reaches the end
     * the values will wrap back around to the 0th id. 
     */
    // An index may have been removed during the course of a turn. 
    fixIndex();
    string result = ids[nextMonIndex];
    incrementIndex();
    return result;
  }

  void incrementIndex() {
    nextMonIndex += 1;
    fixIndex();
  }

  void fixIndex() {
    if ((nextMonIndex < 0) || (nextMonIndex >= ids.Count)) {
      // If the index somehow became negative, or larger
      // than this.ids List then loop back to 0.
      nextMonIndex = 0;
    }
  }

}
