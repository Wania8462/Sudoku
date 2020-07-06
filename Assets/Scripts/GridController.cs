using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sudoku;
using System;
using UnityEngine.SceneManagement;

public class GridController : MonoBehaviour
{
    [SerializeField] GameObject CellPrefab; // объект
    int ShiftX = -200;
    int ShiftY = 200;
    int cellSize = 53;

    private CellController[,] _cells = new CellController[9, 9];
    Puzzle _puzzle;
    CellController _clickedCellController; // выделеная яечкйка
    void Start()
    {
        _puzzle = PuzzleGame.Instance.GetNewGame(1);

        for (int x = 0; x < 9; x++)
        {
            for (int y = 0; y < 9; y++)
            {
                PuzzleCell cell = _puzzle.GetCell(x, y);
                cell.OnCellOpen += OnCellOpened;
                var cellButton = GameObject.Find($"{x}_{y}");

                CellController controller = cellButton.GetComponent<CellController>();
                controller.Cell = cell;
                controller.X = x;  //колонка
                controller.Y = y;  //строка
                controller.CellName = cellButton.name;
                controller.CellClicked += OnCellClicked;
                _cells[x, y] = controller;
                controller.DrawCell();
            }
        }

        //Find keypad buttons
        for (int i = 1; i < 10; i++)
        {
            var keyPadButton = GameObject.Find($"Num{i}").GetComponent<Button>();
            int number = i;
            keyPadButton.onClick.AddListener(() => OnKeyPadButtonClicked(number));
        }
    }

    private void OnKeyPadButtonClicked(int number) // на нум паде
    {
        if (!_clickedCellController.Cell.IsOpen)
        {
            if (_clickedCellController.Cell.Value == number)
            {
                _clickedCellController.Cell.Open();
                _clickedCellController.DrawCell(); 
            }
        }
    }

    private void OnCellOpened(object sender, EventArgs e) 
    {
        if (_puzzle.IsSolved())
        {
            SceneManager.LoadScene("win");
            //На экране попеды должна быть кнопка Next Level
            //Подумай, как можно перейти на следующий уровень
        }
    }
    private void OnCellClicked(object sender, EventArgs e)
    {
        _clickedCellController = (CellController)sender;
        _clickedCellController.ChangeColor(CellColor.Highlighted);
        bool isOpen = _clickedCellController.Cell.IsOpen;
        int number = _clickedCellController.Cell.Value;
        int square = _clickedCellController.Square;
        for (int i = 0; i < 9; i++)  // X, колонка
        {
            for (int j = 0; j < 9; j++)  // Y, строка
            {
                // подсвечивание "плюсика"
                if (i == _clickedCellController.X || j == _clickedCellController.Y)
                {
                    _cells[i, j].ChangeColor(CellColor.Gray);
                }

                // подсвечивание такихже цифр
                else if (_cells[i, j].Cell.IsOpen && isOpen && _cells[i, j].Cell.Value == number)
                {
                    _cells[i, j].ChangeColor(CellColor.Gray);
                }

                // подсвечивание кубиков
                else if (_cells[i, j].Square == square)
                {
                    _cells[i, j].ChangeColor(CellColor.Gray);
                }

                // ничего не делать
                else
                {
                    _cells[i, j].ChangeColor(CellColor.Normal);
                }
            }
        }
    }
}