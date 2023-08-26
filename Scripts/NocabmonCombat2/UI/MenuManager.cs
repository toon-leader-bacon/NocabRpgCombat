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

    /**
     * 2d array of buttons. The buttons are in the list to mirror how they appear on the screen,
     * with the (x,y) coordinates corresponding to the array indexes
     * So menuButtons[0][0]; is the top left button while menuButtons[1][1] is the bot right.
     * In other words, this is a list of columns. The first index (x) specifies which column to select
     * while the second index (y) selects a row.
     */
    protected List<List<Button>> menuButtons = new List<List<Button>>(); // 2d array of buttons

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
        List<Button> colX0 = new List<Button>(2);
        colX0.Add(attackButton); // (0,0) Top Left
        colX0.Add(magicButton); // (0,1) Bottom Left

        List<Button> colX1 = new List<Button>(2);
        colX1.Add(itemButton); // (1,0) Top Right
        colX1.Add(runButton); // (1,1) Bottom Right

        menuButtons.Add(colX0);
        menuButtons.Add(colX1);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2Int menuMoveDir = new Vector2Int(0, 0);
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            menuMoveDir.y += 1;
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            menuMoveDir.y -= 1;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            menuMoveDir.x += 1;
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            menuMoveDir.x -= 1;
        }
        if (menuMoveDir != new Vector2Int(0, 0))
        {
            // Only change highlighting if we move
            ChangeHighlightedButton(menuMoveDir);
        }

        if (Input.GetKeyUp(KeyCode.Return))
        {
            PressHighlightedButton();
        }
    }

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

    private void ChangeHighlightedButton(Vector2Int directionMove)
    {
        // Deselect the current button
        menuButtons[currentSelected.x][currentSelected.y].Select();

        // Calculate the newly selected position
        // [Attack] [Item]
        // [Magic ] [Run ]
        int vertMenuLength = 2;
        int horizMenuLength = 2;
        currentSelected.x =
            (currentSelected.x + directionMove.x + horizMenuLength) % horizMenuLength;
        currentSelected.y = (currentSelected.y + directionMove.y + vertMenuLength) % vertMenuLength;

        // Select the new button
        menuButtons[currentSelected.x][currentSelected.y].Select();
    }

    private void PressHighlightedButton()
    {
        menuButtons[currentSelected.x][currentSelected.y].onClick.Invoke();
    }
}
