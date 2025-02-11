using System.Collections.Generic;
using System.Linq;

namespace cli_life
{
    public class Cell
    {
        public bool IsAlive;
        public readonly List<Cell> neighbors = new List<Cell>();
        private bool IsAliveNext;
        public void DetermineNextLiveState()
        {
            int liveNeighbors = neighbors.Where(x => x.IsAlive).Count();
            if (IsAlive)
                IsAliveNext = liveNeighbors == 2 || liveNeighbors == 3;
            else
                IsAliveNext = liveNeighbors == 3;
        }
        public void Advance()
        {
            IsAlive = IsAliveNext;
        }

        public override bool Equals(object obj)
        {
            if (obj as Cell == null)
                return false;
            Cell evaluated = (Cell) obj;
            if (evaluated.IsAlive == IsAlive)
                return true;
            else
                return false;
        }
    }
}