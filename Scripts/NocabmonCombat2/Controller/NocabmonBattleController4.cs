using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class NocabmonBattleController4 : MonoBehaviour
{
    public NocabmonFactory factory;

    public MenuManager menuManager;

    BattleState state = new();
    bool battleOver = false;
    int turnCount = 0;

    public void Start()
    {
        // arguments to construct a BattleController is basically just a BattleState


        BattleState state =
            new()
            {
                enemymon = factory.BuildNocabmon(), //
                currentTurn = true
            };

        this.state = state;

        // TODO: This function
        menuManager.displayPlayerNocabmon();
    }

    public void Update()
    {
        Debug.Log($"Begin turn #{turnCount}");
        if (battleOver)
        {
            Debug.Log("battle is over");
            return;
        }

        INocabmon currentMon = state.currentTurn ? state.playermon : state.enemymon;
        IAction? selectedAction = currentMon.SelectAction();
        if (selectedAction == null)
        {
            Debug.Log("Still thinking...");
            return;
        }
        INocabmon targetMon = state.currentTurn ? state.enemymon : state.playermon;
        targetMon.ApplyAction(selectedAction);

        //  Update the view
        Debug.Log($"======================");
        Debug.Log($"Team true hp: {state.playermon.Stats.HP_Value}");
        Debug.Log($"Team false hp: {state.enemymon.Stats.HP_Value}");
        Debug.Log($"======================");

        if (targetMon.IsDead())
        {
            Debug.Log("Target mon is dead!");
            this.battleOver = true;
            return;
        }
        // Else the battle continues
        state.currentTurn = !state.currentTurn;
        turnCount += 1;
    }
}
