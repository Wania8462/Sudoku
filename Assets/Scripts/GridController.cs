using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sudoku;

public class GridController : MonoBehaviour
{
    [SerializeField] GameObject CellPrefab; // объект
        int ShiftX = -200;
        int ShiftY = -100;
        int cellSize = 53;
    void Start()
    {
        var puzzle = PuzzleGame.Instance.GetNewGame();
        for (int x = 0; x < 9; x++)
        {
            for (int y = 0; y < 9; y++)
            {
                PuzzleCell cell = puzzle.GetCell(x, y);
                string cellName = $"Cell{x}_{y}";
                
                int xCoord = ShiftX + x*cellSize;
                int yCoord = ShiftY + y*cellSize;

                GameObject cellButton = Instantiate(CellPrefab, new Vector3(xCoord, yCoord, 0), Quaternion.identity); // (x, y, z) где будут стоять поле для цифр
                cellButton.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
                
                var controller = cellButton.GetComponent<CellController>();
                controller.Cell = cell;
                cellButton.name = cellName;
                controller.CellName = cellName;
                
            }
        }
    }
    void Update()
    {
       
    }
}
