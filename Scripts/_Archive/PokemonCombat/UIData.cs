using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIData
{

  // A mapping of UnitID to their personal HP slider
  private Dictionary<string, StatusValue_MonoUI> sliderMap = new Dictionary<string, StatusValue_MonoUI>();

  public void addMob(string unitID, StatusValue_MonoUI uiElem) {
    sliderMap[unitID] = uiElem;
  }

  public StatusValue_MonoUI getUiElement(string unitID) {
    if ( ! this.sliderMap.ContainsKey(unitID)) {
      throw new System.ArgumentException($"Unknown UnitID: \"{unitID}\"");
    }
    return sliderMap[unitID];
  }

  
}
