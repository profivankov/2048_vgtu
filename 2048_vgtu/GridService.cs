using System;
using System.Collections.Generic;
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
            //mainGrid[1, 1] = 2;
            //mainGrid[1, 3] = 4;

            for (int i = 0; i < 2; i++)
            {
                mainGrid[random.Next(0, 4), random.Next(0, 4)] = 2;
            }
        }

        public void AddNewNumberToGrid(int[,] mainGrid)
        {
            var counter = 0;
            while (counter != 1)
            {
                var row = random.Next(0, 4);
                var column = random.Next(0, 4);

                if (mainGrid[column, row] == 0)
                {
                    mainGrid[column, row] = 2;
                    counter++;
                }
            }
        }

        public void AddNumbersRight()
        {
            for (int rows = 0; rows < 4; rows++)
            {
           // int rows = 1;
            bool collision = false;
                for (int mainCol = 3; mainCol >= 0; mainCol--)
                {
                    for (int col = mainCol; col >= 0; col--) //iterate through FIRST row
                    {
                        if (mainGrid[rows, col] != 0)  //if window not empty
                        {
                            if ((mainGrid[rows, col] == mainGrid[rows, mainCol]) && (IsPathClear(col, mainCol, rows) == true) && collision == false) //and if values are equal AND path between them clear, add them up
                            {
                                mainGrid[rows, mainCol] = mainGrid[rows, col] * 2;
                                mainGrid[rows, col] = 0;
                                collision = true;
                            }
                            else   //if not equal check for free space AND move them to side if ((mainGrid[0, col] != mainGrid[0, 3]) && (CheckForSpace(col, 3) != 0))
                            {
                               // var freeColLeft = CheckForSpaceLeft(col, mainCol, rows);
                                var freeColRight = CheckForSpaceRight(col, mainCol, rows);
                                //if (freeColLeft != col)
                                //{
                                //    mainGrid[rows, freeColLeft] = mainGrid[rows, col];
                                //    mainGrid[rows, col] = 0;
                                //}
                                //else
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
        }

        public void AddNumbersLeft()
        {
            for (int rows = 0; rows < 4; rows++)
            {
            //int rows = 1;
                bool collision = false;
                for (int mainCol = 0; mainCol < 4; mainCol++)
                {
                    for (int col = mainCol; col < 4; col++) //iterate through FIRST row
                    {
                        if (mainGrid[rows, col] != 0)  //if window not empty
                        {
                            if ((mainGrid[rows, col] == mainGrid[rows, mainCol]) && (IsPathClear(col, mainCol, rows) == true) && collision == false) //and if values are equal AND path between them clear, add them up
                            {
                                mainGrid[rows, mainCol] = mainGrid[rows, col] * 2;
                                mainGrid[rows, col] = 0;
                                collision = true;
                            }
                            else   //if not equal check for free space AND move them to side 
                            {
                                var freeColLeft = CheckForSpaceLeft(col, mainCol, rows) ;
                                //var freeColRight = CheckForSpaceRight(mainCol, col, rows);
                                //if (freeColRight != mainCol)
                                //{
                                //    mainGrid[rows, freeColRight] = mainGrid[rows, col];
                                //    mainGrid[rows, col] = 0;
                                //}
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


            //for (int col = lastPos - 1; col >= firstPos; col--)
            //{
            //    if (mainGrid[rows, col] == 0)
            //    {
            //        return col;
            //    }
            //}


            return firstPos;
        }

        public int CheckForSpaceRight(int firstPos, int lastPos, int rows)
        {
            for (int col = lastPos; col > firstPos; col--)
            {
                if (mainGrid[rows, col] == 0)
                {
                    return col;
                }
            }

            for (int col = firstPos; col <= lastPos; col++)
            {
                if (mainGrid[rows, col] == 0)
                {
                    return col;
                }
            }



            return firstPos;
        }
        public bool IsPathClear(int firstPos, int lastPos, int rows)
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

    }
}
