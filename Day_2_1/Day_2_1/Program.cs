using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string filePath = @"C:\Users\jenst\Desktop\JENS_AO_24_25\AdventOfCode\Day_2_1\Input.txt";

        var lines = File.ReadAllLines(filePath);

        int safe = 0;

        foreach (var line in lines)
        {
            var numbers = line.Split(' ').Select(int.Parse).ToArray();

            safe += IsSafe(numbers) ? 1 : 0;
            
        }

        Console.WriteLine($"Safe reports " + safe);

        static bool IsSafe(int[] numbers)
        {
            bool isIncreasing = true;
            bool isDecreasing = true;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                int diff = numbers[i + 1] - numbers[i];

                if(Math.Abs(diff) > 3 || diff == 0)
                    return false;

                if (diff < 0)
                    isIncreasing = false;

                if (diff > 0)
                    isDecreasing = false;
            }

            return isIncreasing || isDecreasing;
        }
    }
}