using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        string filePath = @"C:\Users\jenst\Desktop\JENS_AO_24_25\AdventOfCode\Day_3_1\Input.txt";

        var lines = File.ReadAllLines(filePath);

        string pattern = @"mul\((\d+),(\d+)\)";
        
        int result = 0;

        foreach (var line in lines )
        {
            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(line);

            foreach (Match match in matches)
            {
                string firstNumber = match.Groups[1].Value;
                string secondNumber = match.Groups[2].Value;

                if (int.TryParse(firstNumber, out int num1) && int.TryParse(secondNumber, out int num2))
                {
                   int product = num1 * num2;
                   result += product;
                }
            }             
        }

        Console.WriteLine($"Result of the multiplications = {result}");
    }
}