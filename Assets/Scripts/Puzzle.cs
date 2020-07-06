using System.Collections;
using System.Collections.Generic;

namespace Sudoku
{
    public class Puzzle
    {
        private PuzzleCell[][] _board;

        public Puzzle(int[][] initialBoard, int[][] solution)
        {
            _board = new PuzzleCell[9][];
            for (int i = 0; i < 9; i++)
            {
                _board[i] = new PuzzleCell[9];
                for (int j = 0; j < 9; j++)
                {
                    int value = solution[i][j];
                    bool isOpen = false;
                    if (initialBoard[i][j] != 0)
                    {
                        isOpen = true;
                    }

                    _board[i][j] = new PuzzleCell(value, isOpen);
                }
            }
        }

        public PuzzleCell GetCell(int i, int j)
        {
            return _board[i][j];
        }

        public bool IsSolved()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (!_board[i][j].IsOpen)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}