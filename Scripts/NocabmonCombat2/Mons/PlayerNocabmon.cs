using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerNocabmon : INocabmon
{
    protected MenuManager battleMenu { get; set; }
    protected int actionIndexPicked = -1;

    public INocabmon mon { get; set; }

    IAction? selectedAction = null;

    void Start() { }

    public void setBattleMenu(MenuManager battleMenu_)
    {
        battleMenu = battleMenu_;
        battleMenu.setActionCallback(this.setActionIndexPicked);
    }

    public void setActionIndexPicked(int newValue)
    {
        Debug.Log($"Player nocabmon setting action index to new value: {newValue}");
        actionIndexPicked = newValue;
    }

    protected override IAction? SelectActionDefaultBehaviour()
    {
        if (actionIndexPicked < 0)
        {
            Debug.Log("Player nocabmon returning null action");
            return null;
        }
        Debug.Log("Player nocabmon returning action");
        actionIndexPicked = Mathf.Clamp(actionIndexPicked, 0, mon.PossibleActions.Count - 1);
        return this.mon.PossibleActions[actionIndexPicked];
    }

    public override void ApplyAction(IAction action)
    {
        this.mon.ApplyAction(action);
    }

    public override bool IsDead()
    {
        return this.mon.IsDead();
    }
}
