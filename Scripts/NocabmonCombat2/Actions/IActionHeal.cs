using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActionHeal : IAction {

  /**
   * @brief The amount of damage to heal as an unsigned
   * int to avoid confusion of "dealing negative damage" 
   * or "healing a positive amount"
   * It's the callers responsibility to use the amount appropriately
   */
  uint amountToHeal();
}