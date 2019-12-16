using Game.Contracts;

namespace Game.Services
{
    public class MovementService : IMovementService
    {
        public IScoutingService scoutingService;

        public MovementService(IScoutingService _scoutingService)
        {
            scoutingService = _scoutingService;
        }
        public bool AddNumbersUp(int[,] mainGrid)
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
                            if ((mainGrid[rows, col] == mainGrid[mainRow, col]) && (scoutingService.IsPathClearVertically(mainGrid, mainRow, rows, col) == true) && collision < 2) //and if values are equal AND path between them clear, add them up
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
                                var freeRowUp = scoutingService.CheckForSpaceUp(mainGrid, rows, mainRow, col);
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

            return scoutingService.CheckIfArraysEqual(mainGrid, tempGrid);
        }

        public bool AddNumbersDown(int[,] mainGrid)
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
                            if ((mainGrid[rows, col] == mainGrid[mainRow, col]) && (scoutingService.IsPathClearVertically(mainGrid, rows, mainRow, col) == true) && collision <= 2) //and if values are equal AND path between them clear, add them up
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
                                var freeRowDown = scoutingService.CheckForSpaceDown(mainGrid, rows, mainRow, col);
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

            return scoutingService.CheckIfArraysEqual(mainGrid, tempGrid);
        }

        public bool AddNumbersRight(int[,] mainGrid)
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
                            if ((mainGrid[rows, col] == mainGrid[rows, mainCol]) && (scoutingService.IsPathClearHorizontally(mainGrid, col, mainCol, rows) == true) && collision < 2) //and if values are equal AND path between them clear, add them up
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
                                var freeColRight = scoutingService.CheckForSpaceRight(mainGrid, col, mainCol, rows);
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

            return scoutingService.CheckIfArraysEqual(mainGrid, tempGrid);
        }

        public bool AddNumbersLeft(int[,] mainGrid)
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
                            if ((mainGrid[rows, col] == mainGrid[rows, mainCol]) && (scoutingService.IsPathClearHorizontally(mainGrid, mainCol, col, rows) == true) && collision < 2) //and if values are equal AND path between them clear, add them up
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
                                var freeColLeft = scoutingService.CheckForSpaceLeft(mainGrid, col, mainCol, rows);
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

            return scoutingService.CheckIfArraysEqual(mainGrid, tempGrid);
        }
    }
}
