using DataStructures;
using PiCross;
using Cells;

namespace ViewModel
{
    public class ConstraintsViewModel
    {
        private IPlayablePuzzleConstraints constraints;

        public ConstraintsViewModel(IPlayablePuzzleConstraints constraints)
        {
            this.constraints = constraints;
            this.Values = constraints.Values.Map((IPlayablePuzzleConstraintsValue value) => new ConstraintsValueViewModel(value)).Copy();
        }

        public ISequence<ConstraintsValueViewModel> Values { get; }

        public Cell<bool> IsSatisfied => constraints.IsSatisfied;
    }
}