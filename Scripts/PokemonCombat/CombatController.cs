using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour {
    /**
     * An overseer that is responsible for managing a Pokemon style combat
     */

    public NocabmonMono prefabMono;


    public bool isTeam1Turn = true;

    public NocabmonMono team1_;
    public NocabmonMono team2_;

    void Start() {
        Nocabmon team1Data = new Nocabmon(100);
        Nocabmon team2Data = new Nocabmon(80);

        team1_ = Object.Instantiate(prefabMono, this.transform);
        team2_ = Object.Instantiate(prefabMono, this.transform);

        team1_.swapData(team1Data);
        team2_.swapData(team2Data);
    }

    // Update is called once per frame
    void Update()  {
        if (Time.frameCount % GlobalConstants.FRAMES_PER_GAME_TICK == 0) {
            // Play the game

            if (isTeam1Turn) {

            } else {

            }
        }
    }

    void executeAction(Action action) {
        // Execute provided action on target
    }
}
