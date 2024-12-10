using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        string filePath = @"C:\Users\jenst\Desktop\JENS_AO_24_25\AdventOfCode\Day_5_1\input.txt";

        var lines = File.ReadAllLines(filePath);

        // Splits de regels in twee secties: regels en updates
        var rules = lines.TakeWhile(line => line.Contains('|')).ToList();
        var updates = lines.Skip(rules.Count).Where(line => !string.IsNullOrWhiteSpace(line)).ToList();

        // Parse de regels naar een lijst van paren
        var pageRules = rules.Select(line => Regex.Match(line, @"^(?<before>\d+)\|(?<after>\d+)$"))
                             .Select(match => (int.Parse(match.Groups["before"].Value), int.Parse(match.Groups["after"].Value)))
                             .ToList();
        
        int totalMiddleSum = 0;

        // Controleer elke update
        foreach (var update in updates)
        {
            // Parse de update naar een lijst van pagina's
            var pages = update.Split(',').Where(s => int.TryParse(s, out _)).Select(int.Parse).ToList();                           

            //int middleValue = GetMiddleValue(pages);
            int middleValue = pages[pages.Count / 2];

            // Selecteer alleen de relevante regels
            var relevantRules = pageRules.Where(rule => pages.Contains(rule.Item1) && pages.Contains(rule.Item2)).ToList();

            // Controleer of de regels worden gerespecteerd
            bool isValid = true;
            foreach (var rule in relevantRules)
            {
                if (pages.IndexOf(rule.Item1) >= pages.IndexOf(rule.Item2))
                {
                    isValid = false;
                    break; // Stop de controle als een regel wordt overtreden
                }
            }

            // Print het resultaat
            if (isValid)
            {
                Console.WriteLine($"True: Geldige update: {update}, Midden-getal: {middleValue}");
                totalMiddleSum += middleValue;
            }
            else
            {
               continue;
            }
        }

        Console.WriteLine($"Totale som van alle midden-getallen: {totalMiddleSum}");
    }

}