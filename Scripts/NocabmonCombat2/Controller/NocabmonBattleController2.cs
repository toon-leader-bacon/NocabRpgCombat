using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class NocabmonBattleController2 : MonoBehaviour
{
    public INocabmon playerMon;
    public INocabmon enemyMon;

    public bool gameOver = false;

    // True team always goes first
    // True = player
    private bool currentTurn { get; set; } = true;

    void Start() { }

    void Update() {
        
    }

    void runBattle()
    {
        Debug.Log($"Run battle for current turn: {currentTurn}");
        Action<IAction> callbackLambda = (IAction action) =>
        {
            applyActionCallback(action, currentTurn);
        };
        INocabmon currentMon = currentTurn ? playerMon : enemyMon;
        // currentMon.selectAction(callbackLambda);
    }

    void nextTurn()
    {
        currentTurn = !currentTurn;
        runBattle();
    }

    void applyActionCallback(IAction action, bool target)
    {
        Debug.Log($"applyActionCallback for current turn: {currentTurn}");
        // (target == true) => target is player
        // (target == false) => target is enemy
        INocabmon targetMon = target ? playerMon : enemyMon;
        targetMon.ApplyAction(action);
        // Move to the next action
        nextTurn();
    }
}; // public class NocabmonBattleController2 : MonoBehaviour
