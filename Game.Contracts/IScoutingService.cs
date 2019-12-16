
namespace Game.Contracts
{
    public interface IScoutingService
    {
        public int CheckForSpaceUp(int[,] mainGrid, int firstPos, int lastPos, int col);
        public int CheckForSpaceDown(int[,] mainGrid, int firstPos, int lastPos, int col);
        public int CheckForSpaceLeft(int[,] mainGrid, int firstPos, int lastPos, int rows);
        public int CheckForSpaceRight(int[,] mainGrid, int firstPos, int lastPos, int rows);
        public bool IsPathClearHorizontally(int[,] mainGrid, int firstPos, int lastPos, int rows);
        public bool IsPathClearVertically(int[,] mainGrid, int firstPos, int lastPos, int cols);
        public bool CheckIfArraysEqual(int[,] mainGrid, int[,] tempGrid);

    }
}
