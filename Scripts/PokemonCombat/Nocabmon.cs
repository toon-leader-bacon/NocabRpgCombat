using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NocabmonMono : MonoBehaviour {
    /** 
     * A Nocabmon is a custom rolled Pokemon Monobehaviour. Current emphasis
     * is on geting a simple thing to work, and optimizing it later.
     */

    private Nocabmon nocabMonData;

    public Nocabmon swapData(Nocabmon newData) {
        Nocabmon result = this.nocabMonData;
        this.nocabMonData = newData;
        return result;
    }
    
    void Start() {
    }


    void Update() {

    }

    void runTurn() {
        // Lookup who the enemy is
        // Pick a move to use vs the enemy
        // return that action
    }

    void applyActionOnMe(Action action) {
        // Take the provided action, and execute it vs this mon

        if ( ! action.isSpecial) {
            // If the action is NOT special (IE mundane)
        }
    }

    private bool subtractHP(int processedDmg) {
        /**
         * WARNING! This method changes the underlying HP value of the Nocabmon data
         * container. Typically, you don't want to call this funciton directly. Instead
         * please consider using the applyActionOnMe(...) funciton.
         * 
         * @param processedDmg The true damage to subtract to the data model.
         * @returns True if the new HP is below 0, false otherwise. True => this damage
         * hit has killed the mon.
         */
        return false;
    }
}

public class Nocabmon {
    /** A data model to represent a Nocabmon */
    public StatusValue HP_;
    public StatusValue Energy_;

    // TODO: Make single skills like this some kind of class? With good typing?
    public int Attack_;
    public int Defense_;

    public Nocabmon(int maxHP) {
        this.HP_ = new StatusValue(maxHP, maxHP);

        // Todo: accept in a better max energy?
        this.Energy_ = new StatusValue(100, 0);

        this.Attack_ = 10;
        this.Defense_ = 5;
    }
}