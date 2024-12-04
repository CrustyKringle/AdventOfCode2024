using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string filePath = @"C:\Users\jenst\Desktop\JENS_AO_24_25\AdventOfCode\Day_4_1\input.txt";

        var lines = File.ReadAllLines(filePath);
        char[][] grid = ConvertToGrid(lines);

        var foundWords = FindPattern(grid, "XMAS");
        Console.WriteLine("Resultaat: ");
        PrintResults(grid, foundWords);
    }

    static char[][] ConvertToGrid(string[] lines)
    {
        char[][] grid = new char[lines.Length][];
        for (int i = 0; i < lines.Length; i++)
        {
            grid[i] = lines[i].ToCharArray();
        }
        return grid;
    }

    static List<string> FindPattern(char[][] grid, string word)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;
        var foundWords = new List<string>();

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (grid[i][j] == word[0])
                {
                    SearchInAllDirections(grid, i, j, word, foundWords);
                }
            }
        }
        return foundWords;
    }

    static void SearchInAllDirections(char[][] grid, int startX, int startY, string word, List<string> foundWords)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;

        int[] dx = { -1, -1, -1, 0, 0, 1, 1, 1 };
        int[] dy = { -1, 0, 1, -1, 1, -1, 0, 1 };

        for (int dir = 0; dir < 8; dir++)
        {
            int x = startX, y = startY, k;
            for (k = 0; k < word.Length; k++)
            {
                if (x < 0 || x >= rows || y < 0 || y >= cols || grid[x][y] != word[k])
                    break;

                x += dx[dir];
                y += dy[dir];
            }

            if (k == word.Length)
            {
                foundWords.Add($"Patroon gevonden: {word} startend bij ({startX},{startY}) richting {dir}");
            }
        }
    }

    static void PrintResults(char[][] grid, List<string> foundWords)
    {
        Console.WriteLine($"Gevonden woorden/patronen ({foundWords.Count}):");
        foreach (var word in foundWords)
        {
            Console.WriteLine(word);
        }
    }
}