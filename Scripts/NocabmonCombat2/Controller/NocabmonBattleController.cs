using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class NocabmonBattleController : MonoBehaviour
{
    void Start()
    {
        // Set up two teams
        NocabmonFactory factory = new NocabmonFactory();
        INocabmon playerMon = factory.BuildNocabmon();
        INocabmon enemyMon = factory.BuildUndead();

        runBattle(playerMon, enemyMon);
    }

    void runBattle(INocabmon playerMon, INocabmon enemyMon)
    {
        bool gameOver = false;
        // True team always goes first
        // True = player
        bool currentTurn = true;

        while (!gameOver)
        {
            // Poll that team for an action
            if (currentTurn)
            {
                bool playerMonWins = simulateTurn(playerMon, enemyMon);
                if (playerMonWins)
                {
                    Debug.Log("Team True wins!");
                    gameOver = true;
                }
            }
            else
            {
                // Else enemyMon turn
                bool enemyMonWins = simulateTurn(enemyMon, playerMon);
                if (enemyMonWins)
                {
                    Debug.Log("Team True wins!");
                    gameOver = true;
                }
            }
            currentTurn = !currentTurn;
        }
    }

    bool simulateTurn(INocabmon activeTeam, INocabmon targetTeam)
    {
        IAction action = activeTeam.SelectAction();
        targetTeam.ApplyAction(action);
        if (targetTeam.IsDead())
        {
            Debug.Log("Target has died.");
            return true; // game over
        }
        return false; // game on
    }
}
