using System;

namespace _2048_vgtu
{
    public class Program
    {
        static void Main()
        {
            var drawing = new DrawingService();
            var gridService = new GridService();

            // initialize grid and insert two 2's in random spots
            gridService.SetNewGrid();

            // draw grid
            drawing.PrintTable(gridService.mainGrid);

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
                    var changes = !gridService.AddNumbersRight();
                    if (changes == true)
                    {
                        gridService.AddNewNumberToGrid();
                    }
                    drawing.PrintTable(gridService.mainGrid);
                }

                else if (key == ConsoleKey.A)
                {

                    Console.Clear();
                    var changes = !gridService.AddNumbersLeft();
                    if (changes == true)
                    {
                        gridService.AddNewNumberToGrid();
                    }
                    drawing.PrintTable(gridService.mainGrid);

                }

                else if (key == ConsoleKey.S)
                {
                    Console.Clear();
                    var changes = !gridService.AddNumbersDown();
                    if (changes == true)
                    {
                        gridService.AddNewNumberToGrid();
                    }
                    drawing.PrintTable(gridService.mainGrid);
                }

                else if (key == ConsoleKey.W)
                {
                    Console.Clear();
                    var changes = !gridService.AddNumbersUp();
                    if (changes == true)
                    {
                        gridService.AddNewNumberToGrid();
                    }
                    drawing.PrintTable(gridService.mainGrid);
                }

            } while (key != ConsoleKey.Escape);

        }

    }
}

