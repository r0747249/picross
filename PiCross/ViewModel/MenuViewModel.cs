using PiCross;
using System;
using System.Linq;
using System.Collections.Generic;

namespace ViewModel
{
    public class MenuViewModel
    {
        public MenuViewModel(Action<Puzzle> puzzleScreenSwitcher)
        {
            var facade = new PiCrossFacade();
            IGameData gameData = facade.CreateDummyGameData();
            this.Choices = gameData.PuzzleLibrary.Entries.Select((IPuzzleLibraryEntry s) => new ChoiceViewModel(s.Puzzle, puzzleScreenSwitcher));
        }

        public IEnumerable<ChoiceViewModel> Choices { get; }
    }
}
