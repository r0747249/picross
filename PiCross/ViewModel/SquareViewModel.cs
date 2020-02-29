using Cells;
using PiCross;
using System.Windows.Input;

namespace ViewModel
{
    public class SquareViewModel
    {
        private IPlayablePuzzleSquare square;

        public SquareViewModel(IPlayablePuzzleSquare square)
        {
            this.square = square;
            this.Cycle = new EnabledCommand(PerformCycle);
        }

        public Cell<Square> Contents => square.Contents;

        public ICommand Cycle { get; }

        private void PerformCycle()
        {
            if (Contents.Value == Square.UNKNOWN)
                Contents.Value = Square.FILLED;
            else if (Contents.Value == Square.FILLED)
                Contents.Value = Square.EMPTY;
            else
                Contents.Value = Square.UNKNOWN;
        }
    }
}