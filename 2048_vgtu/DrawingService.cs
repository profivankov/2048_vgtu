﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _2048_vgtu
{
    public class DrawingService
    {

        private static int tableWidth = 110;
        private static List<string> stringList = new List<string>();

        public void PrintArray<T>(T[] array, string word)
        {
            PrintColumns(array.GetLength(0) - 1, word);
            for (int i = 0; i < array.GetLength(0); i++)
            {
                stringList.Add(array[i] + " ");
            }
            PrintRow(stringList.ToArray());
            stringList.Clear();
            PrintLine();
            Console.ReadLine();
        }
        public void PrintTable(int[,] array)
        {
            PrintColumns(array.GetLength(1) + 1, " ");
            for (int rows = 0; rows < array.GetLength(0); rows++)
            {
                stringList.Add(" ");
                for (int columns = 0; columns < array.GetLength(1); columns++)
                {
                    if (array[rows, columns] == 0)
                    {
                        stringList.Add("null");
                    }
                    else
                    {
                        stringList.Add(array[rows, columns].ToString());
                    }
                }
                stringList.Add(" ");
                PrintRow(stringList.ToArray());
                stringList.Clear();
                if (rows != array.GetLength(0) - 1)
                {
                    PrintLine();
                }
            }
            PrintColumns(array.GetLength(1) + 1, " ");
            //Console.ReadLine();
        }

        public void PrintColumns(int maxColumns, string word)
        {
            PrintLine();
            for (int columns = 0; columns < maxColumns + 1; columns++)
            {
                stringList.Add(word);
            }
            PrintRow(stringList.ToArray());
            stringList.Clear();
            PrintLine();
        }

        public void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        public void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }

    }
}
