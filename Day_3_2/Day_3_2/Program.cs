using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        string filePath = @"C:\Users\jenst\Desktop\JENS_AO_24_25\AdventOfCode\Day_3_2\input.txt";

        var lines = File.ReadAllLines(filePath);

        string pattern = @"mul\((\d+),(\d+)\)";
        string doInstruction = @"do\(\)";
        string dontInstruction = @"don't\(\)";

        int result = 0;
        bool processing = true; // Staat van de machine, standaard aan

        foreach (var line in lines)
        {
            int currentIndex = 0;

            while (currentIndex < line.Length)
            {
                // Zoek de eerstvolgende do(), don't(), of mul(...)
                Match doMatch = Regex.Match(line[currentIndex..], doInstruction);
                Match dontMatch = Regex.Match(line[currentIndex..], dontInstruction);
                Match mulMatch = Regex.Match(line[currentIndex..], pattern);

                // Vind de eerstvolgende gebeurtenis
                int doIndex = doMatch.Success ? doMatch.Index + currentIndex : int.MaxValue;
                int dontIndex = dontMatch.Success ? dontMatch.Index + currentIndex : int.MaxValue;
                int mulIndex = mulMatch.Success ? mulMatch.Index + currentIndex : int.MaxValue;

                // Bepaal wat als eerste komt
                int nextIndex = Math.Min(doIndex, Math.Min(dontIndex, mulIndex));

                if (nextIndex == int.MaxValue)
                {
                    break;
                }

                if (nextIndex == doIndex)
                {
                    processing = true;
                    currentIndex = doIndex + doMatch.Length;
                }
                else if (nextIndex == dontIndex)
                {
                    processing = false;
                    currentIndex = dontIndex + dontMatch.Length;
                }
                else if (nextIndex == mulIndex)
                {
                    if (processing)
                    {
                        string firstNumber = mulMatch.Groups[1].Value;
                        string secondNumber = mulMatch.Groups[2].Value;

                        if (int.TryParse(firstNumber, out int num1) && int.TryParse(secondNumber, out int num2))
                        {
                            int product = num1 * num2;
                            result += product; 
                        }
                    }

                    currentIndex = mulIndex + mulMatch.Length;
                }
            }
        }

        Console.WriteLine($"Result of the multiplications = {result}");
    }
}