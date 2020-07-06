using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sudoku;

public class CellController : MonoBehaviour
{
    public PuzzleCell Cell {get; set;}
    // Start is called before the first frame update
    void Start()
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
    public void Clicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Pressed");
            //IsClicked = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
