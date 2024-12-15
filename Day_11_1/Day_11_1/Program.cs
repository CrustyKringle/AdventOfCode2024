using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Numerics;


class Program
{
    static void Main(string[] args)
    {
        var initialStones = new List<BigInteger> { 9694820, 93, 54276, 1304, 314, 664481, 0, 4 };
       
        const int blinks = 25;      

        var currentStones = new List<BigInteger>(initialStones);

        for (int i = 0; i < blinks; i++)
        {
            var nextStones = new List<BigInteger>();
            long outputCount = 0;

            foreach (long stone in currentStones)
            {
                if (stone == 0)
                {
                    nextStones.Add(1);
                    outputCount++;
                    continue;
                }

                string stoneString = stone.ToString();
                if (stoneString.Length % 2 == 0)
                {
                    int middle = stoneString.Length / 2;
                    string part1 = stoneString.Substring(0, middle);
                    string part2 = stoneString.Substring(middle);

                    BigInteger leftPart = BigInteger.Parse(part1);
                    BigInteger rightPart = BigInteger.Parse(part2);

                    nextStones.Add(leftPart);
                    nextStones.Add(rightPart);

                    outputCount += 2;
                }
                else
                {
                    BigInteger result = stone * 2024;

                    nextStones.Add(result);
                    outputCount++;
                }
            }
         
            currentStones = nextStones;
            Console.WriteLine($"Aantal stenen na blinks {i + 1}: {outputCount}");
           
        }        
    }
}