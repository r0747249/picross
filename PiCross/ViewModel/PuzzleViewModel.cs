using PiCross;
using System;
using DataStructures;
using Cells;
using System.Windows.Threading;

namespace ViewModel
{
    public class PuzzleViewModel
    {
        private IPlayablePuzzle playablePuzzle;
        private DispatcherTimer timer;
        private DateTime beginTime;

        public PuzzleViewModel(Puzzle puzzle)
        {
            var facade = new PiCrossFacade();
            this.playablePuzzle = facade.CreatePlayablePuzzle(puzzle);
            this.Grid = playablePuzzle.Grid.Map((IPlayablePuzzleSquare s) => new SquareViewModel(s));
            this.ColumnConstraints = playablePuzzle.ColumnConstraints.Map((IPlayablePuzzleConstraints c) => new ConstraintsViewModel(c));
            this.RowConstraints = playablePuzzle.RowConstraints.Map((IPlayablePuzzleConstraints c) => new ConstraintsViewModel(c));
            this.ElapsedTime = Cell.Create(TimeSpan.Zero);
            InitiateTimer();
        }

        public Cell<TimeSpan> ElapsedTime { get; }

        public void InitiateTimer()
        {
            timer = new DispatcherTimer();
            timer.Tick += OnTimerTick;
            timer.Interval = TimeSpan.FromMilliseconds(10);
            beginTime = DateTime.Now;
            timer.Start();
        }

        private void OnTimerTick(object sender, EventArgs args)
        {
            var tijd = DateTime.Now - beginTime;
            this.ElapsedTime.Value = tijd;
        }

        public void IsSolved_ValueChanged()
        {
            timer.Stop();
        }

        public IGrid<SquareViewModel> Grid { get; }
        public ISequence<ConstraintsViewModel> ColumnConstraints { get; }
        public ISequence<ConstraintsViewModel> RowConstraints { get; }

        public Cell<bool> IsSolved => playablePuzzle.IsSolved;
        public Cell<int> UnknownCount => playablePuzzle.UnknownCount;
        public Cell<bool> ContainsUnknowns => playablePuzzle.ContainsUnknowns;
    }
}
