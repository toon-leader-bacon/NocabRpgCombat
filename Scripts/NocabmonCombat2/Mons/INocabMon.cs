using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class INocabmon : MonoBehaviour
{
    public NocabmonStatCollection Stats = new();

    // public virtual NocabmonStatCollection GetStats()
    // {
    //     return stats;
    // }

    // public virtual void SetStats(NocabmonStatCollection newStats) => stats = newStats;

    public List<IAction> PossibleActions = new();

    // public virtual List<IAction> GetPossibleActions()
    // {
    //     return possibleActions;
    // }

    // public virtual void SetPossibleActions(List<IAction> newActions)
    // {
    //     possibleActions = newActions;
    // }

    protected bool ActionStrategyIsSet = false;
    protected Func<IAction?> actionStrategy = () =>
    {
        return null;
    };

    public void SetActionStrategy(Func<IAction?> newActionStrategy)
    {
        actionStrategy = newActionStrategy;
    }

    public virtual IAction? SelectAction()
    {
        if (ActionStrategyIsSet)
        {
            return actionStrategy();
        }
        return SelectActionDefaultBehaviour();
    }

    protected abstract IAction? SelectActionDefaultBehaviour();

    public abstract void ApplyAction(IAction action);

    public abstract bool IsDead();
}
