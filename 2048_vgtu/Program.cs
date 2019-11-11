using System;

namespace _2048_vgtu
{
    class Program
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
                if (key == ConsoleKey.D)
                {
                    Console.Clear();
                    
                    gridService.AddNumbersRight();

                    gridService.AddNewNumberToGrid(gridService.mainGrid);

                    drawing.PrintTable(gridService.mainGrid);
                }
                else if (key == ConsoleKey.A)
                {
                    Console.Clear();

                    gridService.AddNumbersLeft();

                    gridService.AddNewNumberToGrid(gridService.mainGrid);

                    drawing.PrintTable(gridService.mainGrid);
                }

            } while (key != ConsoleKey.Escape);

        }

    }
}

