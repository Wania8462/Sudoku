using System;

namespace Sudoku
{
    public class PuzzleCell
    {
        public event EventHandler<EventArgs> OnCellOpen;

        public PuzzleCell(int value, bool isOpen)
        {
            Value = value;
            IsOpen = isOpen;
        }
        public int Value { get; private set; }

        public bool IsOpen { get; private set; }

        public void Open()
        {
            if (!IsOpen)
            {
                IsOpen = true;

                OnCellOpen?.Invoke(this, new EventArgs());
            }
        }
    }
}
