using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Sudoku;

public class CellController : MonoBehaviour
{
    [SerializeField] Text NumberCell;
    public Button _button;
    public PuzzleCell Cell { get; set; }

    public string CellName { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        _button.onClick.AddListener(Clicked);

        DrawCell();
    }
    void Clicked()
    {
        Debug.Log($"Pressed button {Cell.Value} is open = {Cell.IsOpen}.");

        //TODO: change view
    }

    // Update is called once per frame
    void Update()
    {
        
        //skip if already open
        if (EventSystem.current.currentSelectedGameObject?.name == CellName)
        {
            if ((Input.GetKeyUp(KeyCode.Alpha1) && Cell.Value == 1) ||
            (Input.GetKeyUp(KeyCode.Alpha2) && Cell.Value == 2) ||
            (Input.GetKeyUp(KeyCode.Alpha3) && Cell.Value == 3) ||
            (Input.GetKeyUp(KeyCode.Alpha4) && Cell.Value == 4) ||
            (Input.GetKeyUp(KeyCode.Alpha5) && Cell.Value == 5)
            )
            {
                Cell.Open();
                DrawCell();
            }
        }
    }

    private void DrawCell()
    {
        var cellButtonText = this.GetComponentInChildren<Text>();

        if (Cell.IsOpen)
        {
            cellButtonText.text = Cell.Value.ToString();
        }
        else
        {
            cellButtonText.text = string.Empty;
        }
    }
}
