namespace Sudoku
{
    public class PuzzleCell
    {
        public PuzzleCell(int value, bool isOpen)
        {
            Value = value;
            IsOpen = isOpen;
        }
        public int Value { get; private set;}

        public bool IsOpen { get; private set; }

        public void Open()
        {
            IsOpen = true;
        }
    }
}
