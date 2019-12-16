using Game.Contracts;
using System;

namespace Game.Services
{
    public class GridService : IGridService
    {
        private static Random random;
        public int[,] mainGrid { get; set; }
        public GridService()
        {
            mainGrid = new int[4, 4];
            random = new Random();
        }

        public void SetNewGrid()
        {
            for (int i = 0; i < 2; i++)
            {
                mainGrid[random.Next(0, 4), random.Next(0, 4)] = 2;
            }
        }

        public bool CheckFor2048()
        {
            for (int i = 0; i < mainGrid.GetLength(0); i++)
            {
                for (int j = 0; j < mainGrid.GetLength(1); j++)
                {
                    if (mainGrid[i, j] == 2048)
                    {
                        return true;
                    }

                }
            }

            return false;
        }

        public bool CheckIfGridIsFull()
        {
            for (int i = 0; i < mainGrid.GetLength(0); i++)
            {
                for (int j = 0; j < mainGrid.GetLength(1); j++)
                {
                    if (mainGrid[i,j] == 0)
                    {
                        return false;
                    }
                    
                }
            }

            return true;
        }

        public void AddNewNumberToGrid()
        {
            bool hasBeenAdded = false;
            while (hasBeenAdded == false)
            {
                var row = random.Next(0, 4);
                var column = random.Next(0, 4);

                if (mainGrid[row, column] == 0)
                {
                    mainGrid[row, column] = 2;
                    hasBeenAdded = true;
                }
            }

        }
    }
}
