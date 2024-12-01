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
            if (parts.Length == 2 &&
                int.TryParse(parts[0], out int col1) &&
                int.TryParse(parts[1], out int col2))
            {
                leftColumn.Add(col1);
                rightColumn.Add(col2);
            }
        }

        var similarities = new List<int>();
        foreach (var value in leftColumn)
        {
            int count = rightColumn.Count(x => x == value);     // Count telkens verhogen wanneer een waarde uit de rechterkolom overeenkomt met de linkerkolom.
            similarities.Add(count);
        }

        int similarScore = 0;
        for (int i = 0; i < leftColumn.Count; i++)
        {
            int score = leftColumn[i] * similarities[i];
            similarScore += score;
        }

        Console.WriteLine($"Similar score: {similarScore}");
    }
}
