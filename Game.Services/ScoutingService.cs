using Game.Contracts;
using System;
using System.Linq;

namespace Game.Services
{
    public class ScoutingService : IScoutingService
    {
        public int CheckForSpaceUp(int[,] mainGrid, int firstPos, int lastPos, int col)
        {
            for (int rows = lastPos; rows <= firstPos; rows++)
            {
                if (mainGrid[rows, col] == 0)
                {
                    return rows;
                }
            }

            return firstPos;
        }

        public int CheckForSpaceDown(int[,] mainGrid, int firstPos, int lastPos, int col)
        {
            for (int rows = lastPos; rows >= firstPos; rows--)
            {
                if (mainGrid[rows, col] == 0)
                {
                    return rows;
                }
            }

            return firstPos;
        }

        public int CheckForSpaceLeft(int[,] mainGrid, int firstPos, int lastPos, int rows)
        {
            for (int col = lastPos; col <= firstPos; col++)
            {
                if (mainGrid[rows, col] == 0)
                {
                    return col;
                }
            }

            return firstPos;
        }

        public int CheckForSpaceRight(int[,] mainGrid, int firstPos, int lastPos, int rows)
        {
            for (int col = lastPos; col >= firstPos; col--)
            {
                if (mainGrid[rows, col] == 0)
                {
                    return col;
                }
            }

            return firstPos;
        }

        public bool IsPathClearHorizontally(int[,] mainGrid, int firstPos, int lastPos, int rows)
        {
            if (firstPos == lastPos)
            {
                return false;
            }
            for (int col = firstPos + 1; col < lastPos; col++)
            {
                if (mainGrid[rows, col] != 0)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsPathClearVertically(int[,] mainGrid, int firstPos, int lastPos, int cols)
        {
            if (firstPos == lastPos)
            {
                return false;
            }
            for (int row = firstPos + 1; row < lastPos; row++)
            {
                if (mainGrid[row, cols] != 0)
                {
                    return false;
                }
            }

            return true;
        }

        public bool CheckIfArraysEqual(int[,] mainGrid, int[,] tempGrid)
        {
            var equal =
                tempGrid.Rank == mainGrid.Rank &&
                Enumerable.Range(0, tempGrid.Rank).All(dimension => tempGrid.GetLength(dimension) == mainGrid.GetLength(dimension)) &&
                tempGrid.Cast<int>().SequenceEqual(mainGrid.Cast<int>());

            return equal;
        }

    }
}
