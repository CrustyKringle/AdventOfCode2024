using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string filePath = @"C:\Users\jenst\Desktop\JENS_AO_24_25\AdventOfCode\Day_10_1\input.txt";

        var lines = File.ReadAllLines(filePath);
        char[][] grid = ConvertToGrid(lines);

        int totalScore = CalculateTotalScore(grid);
        Console.WriteLine($"Som van de scores van alle trailheads: {totalScore}");
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

    static int CalculateTotalScore(char[][] grid)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;
        int totalScore = 0;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (grid[i][j] == '0')
                {
                    int score = CalculateTrailHeadScore(grid, i, j);
                    totalScore += score;
                }
            }
        }
        return totalScore;
    }

    static int CalculateTrailHeadScore(char[][] grid, int startX, int startY)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;

        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };

        var visited = new HashSet<(int, int)>();
        var stack = new Stack<(int x, int y, int value)>();

        stack.Push((startX, startY, 0));
        visited.Add((startX, startY));

        int reachableNines = 0;

        while (stack.Count > 0)
        {
            var (x, y, currentValue) = stack.Pop();

            if (currentValue == 9)
            {
                reachableNines++;
                continue;
            }

            for (int dir = 0; dir < 4; dir++)
            {
                int newX = x + dx[dir];
                int newY = y + dy[dir];

                if (newX >= 0 && newX < rows && newY >= 0 && newY < cols && !visited.Contains((newX, newY)) && grid[newX][newY] == (char)(currentValue + 1 + '0'))
                {
                    stack.Push((newX, newY, currentValue + 1));
                    visited.Add((newX, newY));
                }
            }
        }

        return reachableNines;
    }
}