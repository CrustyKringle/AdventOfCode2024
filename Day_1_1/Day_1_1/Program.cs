using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string filePath = @"C:\Users\jenst\Desktop\JENS_AO_24_25\AdventOfCode\Day_1_1\Day_1_1.txt";

        var lines = File.ReadAllLines(filePath);

        var leftColumn = new List<int>();
        var rightColumn = new List<int>();

        foreach (var line in lines)
        {
            var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if(parts.Length == 2 &&
                int.TryParse(parts[0], out int col1) &&
                int.TryParse(parts[1], out int col2))
            {
                leftColumn.Add(col1);
                rightColumn.Add(col2);
            }
        }

        leftColumn.Sort();
        rightColumn.Sort();

        int totalDifference = 0;
        for (int i = 0; i < leftColumn.Count; i++)
        {
            int difference = Math.Abs(leftColumn[i] - rightColumn[i]);
            totalDifference += difference;
        }

        Console.WriteLine($"Total distance: {totalDifference}");
    }
}
