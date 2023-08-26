using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public Button attackButton;
    public Button magicButton;
    public Button itemButton;
    public Button runButton;

    protected List<Button> menuButtons = new List<Button>(4);
    protected Vector2Int currentSelected = new Vector2Int(0, 0); // 0,0 is top left of the button array

    // Start is called before the first frame update
    void Start()
    {
        // Set up onClick behaviour
        attackButton.onClick.AddListener(OnAttackClick);
        magicButton.onClick.AddListener(OnMagicClick);
        itemButton.onClick.AddListener(OnItemClick);
        runButton.onClick.AddListener(OnRunClick);

        // Put buttons into list
        menuButtons.Add(attackButton); // (0,0)
        menuButtons.Add(magicButton); // (0,0)
        menuButtons.Add(itemButton); // (0,0)
        menuButtons.Add(runButton); // (0,0)
    }

    // Update is called once per frame
    void Update() { }

    // Button click functions
    private void OnAttackClick()
    {
        Debug.Log("Attack option selected!");
        // Add your attack logic here
    }

    private void OnMagicClick()
    {
        Debug.Log("Magic option selected!");
        // Add your magic logic here
    }

    private void OnItemClick()
    {
        Debug.Log("Item option selected!");
        // Add your item logic here
    }

    private void OnRunClick()
    {
        Debug.Log("Run option selected!");
        // Add your run logic here
    }
}
