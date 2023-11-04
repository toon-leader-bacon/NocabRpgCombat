using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NocabmonBattleController3 : MonoBehaviour
{
    public PlayerNocabmon playermon = new();
    public INocabmon enemymon;

    public MenuManager menuManager;

    public bool gameOver = false;

    // True team always goes first
    // True = player
    private bool currentTurn { get; set; } = true;

    // Start is called before the first frame update
    void Start()
    {
        NocabmonFactory factory = new NocabmonFactory();
        enemymon = factory.BuildNocabmon();

        playermon.mon = factory.BuildNocabmon();
        menuManager.setPlayerMon(playermon);
        playermon.setBattleMenu(menuManager);
    }

    // Update is called once per frame
    float timePassed = 0f;

    void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed > 5f)
        {
            //do something
            timePassed = 0f;

            Debug.Log($"Update for team: {currentTurn}");
            INocabmon activeMon = currentTurn ? playermon : enemymon;
            IAction? action = activeMon.SelectAction();
            if (action == null)
            {
                return;
            }
            // Else the action was selected
            INocabmon targetMon = currentTurn ? enemymon : playermon;
            targetMon.ApplyAction(action);
            currentTurn = !currentTurn;
        }
    }
}
