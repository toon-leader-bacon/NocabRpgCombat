using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController_Old : MonoBehaviour
{
  /**
   * An overseer that is responsible for managing a Pokemon style combat
   */


  public NocabmonMono prefabMono;
  TurnTracker turnTracker;

  CombatData combatData;


  public HPDrawer hp1;
  public HPDrawer hp2;
  public StatusValue_MonoUI hp2_Slider;

  void Start()
  {
    combatData = new CombatData();

    TeamBuilder builder = new TeamBuilder();
    // Team 1
    combatData.addMobs(builder.buildCloneTeam(
      "Team1", 1, prefabMono, new Nocabmon_old(100)));

    // Team 2
    combatData.addMobs(builder.buildCloneTeam(
      "Team2", 1, prefabMono, new Nocabmon_old(80)));

    // TODO Better ordering of mobs
    turnTracker = new TurnTracker(combatData.getAllUnitIds_List());

    // TODO: Better management of the UI systems
    hp2_Slider.setNewMax(80);
    hp2_Slider.setNewValue(80);

  }



  // Update is called once per frame
  void Update()
  {
    if (Time.frameCount % GlobalConstants.FRAMES_PER_GAME_TICK == 0)
    {
      // Play the game

      string targetMonId = turnTracker.simple();

      // TODO: Try catch around the getMob action. Maybe it died mid turn?
      NocabmonMono targetMon = this.combatData.getMob(targetMonId);

      Action_Old a = targetMon.runTurn(this.combatData);
      this.executeAction(a);
    }
  }

  void executeAction(Action_Old action)
  {
    // Execute provided action on target
    if (!this.combatData.containsMob(action.combatId))
    {
      string warning = $"Invalid action. Can't find target" +
        $"UnitID ({action.combatId}). Skiping action";
      Debug.LogWarning(warning);
      return;
    }

    NocabmonMono targetMon = this.combatData.getMob(action.combatId.UnitID);
    targetMon.applyActionOnMe(action);

    // TODO: Extract this redraw step into dedicated function
    updateMobUI(targetMon);

    if (targetMon.isDead())
    {
      // Run death script
      // TODO: Run death script
      Debug.Log("Someone died!");
    }

  }


  private void updateMobUI(NocabmonMono targetToDisplay)
  {
    if (targetToDisplay.CombatID.TeamID == "Team1")
    {
      hp1.displayNewValue(targetToDisplay.nocabMonData.HP_.Current, targetToDisplay.nocabMonData.HP_.Max);
    }
    else
    {
      hp2.displayNewValue(
        targetToDisplay.nocabMonData.HP_.Current, targetToDisplay.nocabMonData.HP_.Max);
      hp2_Slider.setNewMax(targetToDisplay.nocabMonData.HP_.Max);
      hp2_Slider.redraw_lerp(targetToDisplay.nocabMonData.HP_.Current, 5);
    }
  }

}
