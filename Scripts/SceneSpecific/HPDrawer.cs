using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HPDrawer : MonoBehaviour {

    public TMP_Text text;

    public void displayNewValue(int current, int max) {
        text.text = $"{current} / {max}";
    }

}
