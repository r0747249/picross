using DataStructures;
using PiCross;
using System;
using System.Windows.Input;

namespace ViewModel
{
    public class ChoiceViewModel
    {
        private Puzzle puzzle;
        private Action<Puzzle> switcher;

        public ChoiceViewModel(Puzzle puzzle, Action<Puzzle> puzzleScreenSwitcher)
        {
            this.puzzle = puzzle;
            this.Choice = new EnabledCommand(PerformChoice);
            this.switcher = puzzleScreenSwitcher;
        }

        private void PerformChoice()
        {
            switcher(puzzle);
        }

        public ICommand Choice { get; }
        public Size Size => puzzle.Size;
    }
}