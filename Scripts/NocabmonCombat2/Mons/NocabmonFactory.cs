using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NocabmonFactory : MonoBehaviour
{
    public Nocabmon prefabNocabmon;

    public Nocabmon BuildNocabmon()
    {
        Nocabmon result = Instantiate(prefabNocabmon, new Vector3(0, 0, 0), Quaternion.identity);
        int maxHitPoints = 10;
        List<IAction> possibleActions = new() { new AttackAction(3) };

        result.Stats = buildStatCollection(maxHitPoints);
        result.PossibleActions = possibleActions;
        return result;
    }

    public UndeadNocabmon prefabUndeadNocabmon;

    public INocabmon BuildUndead()
    {
        UndeadNocabmon result = Instantiate(
            prefabUndeadNocabmon,
            new Vector3(0, 0, 0),
            Quaternion.identity
        );
        int maxHitPoints = 8;
        List<IAction> possibleActions = new() { new AttackAction(3) };

        result.Stats = buildStatCollection(maxHitPoints);
        result.PossibleActions = possibleActions;
        return result;
    }

    NocabmonStatCollection buildStatCollection(int maxHP)
    {
        NocabmonStatCollection result = new() { HP_Value = new StatusValue(maxHP) };
        return result;
    }
}
