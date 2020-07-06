using System;
using System.Linq;

namespace Sudoku
{

    public class PuzzleGame
    {
        private static PuzzleGame _instance = new PuzzleGame();
        private PuzzleGame()
        {
        }

        public static PuzzleGame Instance => _instance;

        public Puzzle GetNewGame(int level)
        {
            return Levels.GetLevel(level);
        }
    }
}
