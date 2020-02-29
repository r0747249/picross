using Cells;
using PiCross;

namespace ViewModel
{
    public class ConstraintsValueViewModel
    {

        private IPlayablePuzzleConstraintsValue constraintsValue;

        public ConstraintsValueViewModel(IPlayablePuzzleConstraintsValue constraintsValue)
        {
            this.constraintsValue = constraintsValue;
        }

        public int Value => constraintsValue.Value;
        public Cell<bool> IsSatisfied => constraintsValue.IsSatisfied;
    }
}