using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2048_vgtu
{
    public class GridService
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

        public bool AddNumbersUp()
        {
            var tempGrid = (int[,])mainGrid.Clone();

            for (int col = 0; col < 4; col++)
            {
                var collision = 0;
                for (int mainRow = 0; mainRow < 4; mainRow++)
                {
                    for (int rows = mainRow; rows < 4; rows++) //iterate through FIRST column
                    {
                        if (mainGrid[rows, col] != 0)  //if window not empty
                        {
                            if ((mainGrid[rows, col] == mainGrid[mainRow, col]) && (IsPathClearVertically(mainRow, rows, col) == true) && collision < 2) //and if values are equal AND path between them clear, add them up
                            {

                                if (collision == 0)
                                {
                                    mainGrid[mainRow, col] = mainGrid[rows, col] * 2;
                                    mainGrid[rows, col] = 0;
                                    collision++;
                                }
                                else if (collision == 1 && mainGrid[rows, col] == tempGrid[mainRow, col])
                                {
                                    mainGrid[mainRow, col] = mainGrid[rows, col] * 2;
                                    mainGrid[rows, col] = 0;
                                    collision++;
                                }
                            }
                            else   //if not equal check for free space AND move them to side
                            {
                                var freeRowUp = CheckForSpaceUp(rows, mainRow, col);
                                if (freeRowUp != rows)
                                {
                                    mainGrid[freeRowUp, col] = mainGrid[rows, col];
                                    mainGrid[rows, col] = 0;
                                }

                            }
                        }
                    }
                }
            }

            return CheckIfArraysEqual(tempGrid);
        }

        public bool AddNumbersDown()
        {
            var tempGrid = (int[,])mainGrid.Clone();

            for (int col = 0; col < 4; col++)
            {
                var collision = 0;
                for (int mainRow = 3; mainRow >= 0; mainRow--)
                {
                    for (int rows = mainRow; rows >= 0; rows--) //iterate through FIRST column
                    {
                        if (mainGrid[rows, col] != 0)  //if window not empty
                        {
                            if ((mainGrid[rows, col] == mainGrid[mainRow, col]) && (IsPathClearVertically(rows, mainRow, col) == true) && collision <= 2) //and if values are equal AND path between them clear, add them up
                            {

                                if (collision == 0)
                                {
                                    mainGrid[mainRow, col] = mainGrid[rows, col] * 2;
                                    mainGrid[rows, col] = 0;
                                    collision++;
                                }
                                else if (collision == 1 && mainGrid[rows, col] == tempGrid[mainRow, col])
                                {
                                    mainGrid[mainRow, col] = mainGrid[rows, col] * 2;
                                    mainGrid[rows, col] = 0;
                                    collision++;
                                }
                            }
                            else   //if not equal check for free space AND move them to side
                            {
                                var freeRowDown = CheckForSpaceDown(rows, mainRow, col);
                                if (freeRowDown != rows)
                                {
                                    mainGrid[freeRowDown, col] = mainGrid[rows, col];
                                    mainGrid[rows, col] = 0;
                                }

                            }
                        }
                    }
                }
            }

            return CheckIfArraysEqual(tempGrid);
        }

        public bool AddNumbersRight()
        {
            var tempGrid = (int[,])mainGrid.Clone();

            for (int rows = 0; rows < 4; rows++)
            {
                var collision = 0;
                for (int mainCol = 3; mainCol >= 0; mainCol--)
                {
                    for (int col = mainCol; col >= 0; col--) //iterate through FIRST row
                    {
                        if (mainGrid[rows, col] != 0)  //if window not empty
                        {
                            if ((mainGrid[rows, col] == mainGrid[rows, mainCol]) && (IsPathClearHorizontally(col, mainCol, rows) == true) && collision < 2) //and if values are equal AND path between them clear, add them up
                            {
                                if (collision == 0)
                                {
                                    mainGrid[rows, mainCol] = mainGrid[rows, col] * 2;
                                    mainGrid[rows, col] = 0;
                                    collision++;
                                }
                                else if (collision == 1 && mainGrid[rows, col] == tempGrid[rows, mainCol])
                                {
                                    mainGrid[rows, mainCol] = mainGrid[rows, col] * 2;
                                    mainGrid[rows, col] = 0;
                                    collision++;
                                }

                            }
                            else   //if not equal check for free space AND move them to side
                            {
                                var freeColRight = CheckForSpaceRight(col, mainCol, rows);
                                if (freeColRight != col)
                                {
                                    mainGrid[rows, freeColRight] = mainGrid[rows, col];
                                    mainGrid[rows, col] = 0;
                                }

                            }
                        }
                    }
                }
            }

            return CheckIfArraysEqual(tempGrid);
        }

        public bool AddNumbersLeft()
        {
            var tempGrid = (int[,])mainGrid.Clone();

            for (int rows = 0; rows < 4; rows++)
            {
                var collision = 0;
                for (int mainCol = 0; mainCol < 4; mainCol++)
                {
                    for (int col = mainCol; col < 4; col++)
                    {
                        if (mainGrid[rows, col] != 0)
                        {
                            if ((mainGrid[rows, col] == mainGrid[rows, mainCol]) && (IsPathClearHorizontally(mainCol, col, rows) == true) && collision < 2) //and if values are equal AND path between them clear, add them up
                            {
                                if (collision == 0)
                                {
                                    mainGrid[rows, mainCol] = mainGrid[rows, col] * 2;
                                    mainGrid[rows, col] = 0;
                                    collision++;
                                }
                                else if (collision == 1 && mainGrid[rows, col] == tempGrid[rows, mainCol])
                                {
                                    mainGrid[rows, mainCol] = mainGrid[rows, col] * 2;
                                    mainGrid[rows, col] = 0;
                                    collision++;
                                }
                            }
                            else
                            {
                                var freeColLeft = CheckForSpaceLeft(col, mainCol, rows);
                                if (freeColLeft != col)
                                {
                                    mainGrid[rows, freeColLeft] = mainGrid[rows, col];
                                    mainGrid[rows, col] = 0;
                                }

                            }
                        }
                    }
                }
            }

            return CheckIfArraysEqual(tempGrid);
        }

        public int CheckForSpaceUp(int firstPos, int lastPos, int col)
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

        public int CheckForSpaceDown(int firstPos, int lastPos, int col)
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

        public int CheckForSpaceLeft(int firstPos, int lastPos, int rows)
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

        public int CheckForSpaceRight(int firstPos, int lastPos, int rows)
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

        public bool IsPathClearHorizontally(int firstPos, int lastPos, int rows)
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

        public bool IsPathClearVertically(int firstPos, int lastPos, int cols)
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

        public bool CheckIfArraysEqual(int[,] tempGrid)
        {
            var equal =
                tempGrid.Rank == mainGrid.Rank &&
                Enumerable.Range(0, tempGrid.Rank).All(dimension => tempGrid.GetLength(dimension) == mainGrid.GetLength(dimension)) &&
                tempGrid.Cast<int>().SequenceEqual(mainGrid.Cast<int>());

            return equal;
        }

    }
}
