using Game.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Client
{
    public class Builder
    {
        public IMovementService movementService;
        public IGridService gridService;
        public IDrawingService drawingService;
        public int[,] mainGrid { get; set; }
        public Builder(IMovementService _movementService, IGridService _gridService, IDrawingService _drawingService)
        {
            gridService = _gridService;
            movementService = _movementService;
            drawingService = _drawingService;
            gridService.SetNewGrid();
            mainGrid = gridService.mainGrid;
            drawingService.PrintTable(mainGrid);
        }

        public void Start()
        {
            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;

                if (gridService.CheckIfGridIsFull() == true)
                {
                    Console.WriteLine("Game over!");
                    break;
                }

                if (gridService.CheckFor2048() == true)
                {
                    Console.WriteLine("You win!");
                    break;
                }

                if (key == ConsoleKey.D)
                {
                    Console.Clear();
                    var changes = !movementService.AddNumbersRight(mainGrid);
                    if (changes == true)
                    {
                        gridService.AddNewNumberToGrid();
                    }
                    drawingService.PrintTable(mainGrid);
                }

                else if (key == ConsoleKey.A)
                {

                    Console.Clear();
                    var changes = !movementService.AddNumbersLeft(mainGrid);
                    if (changes == true)
                    {
                        gridService.AddNewNumberToGrid();
                    }
                    drawingService.PrintTable(mainGrid);

                }

                else if (key == ConsoleKey.S)
                {
                    Console.Clear();
                    var changes = !movementService.AddNumbersDown(mainGrid);
                    if (changes == true)
                    {
                        gridService.AddNewNumberToGrid();
                    }
                    drawingService.PrintTable(mainGrid);
                }

                else if (key == ConsoleKey.W)
                {
                    Console.Clear();
                    var changes = !movementService.AddNumbersUp(mainGrid);
                    if (changes == true)
                    {
                        gridService.AddNewNumberToGrid();
                    }
                    drawingService.PrintTable(mainGrid);
                }

            } while (key != ConsoleKey.Escape);

        }

    }
}
