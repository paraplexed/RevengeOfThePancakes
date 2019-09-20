using System;
using System.Collections.Generic;
using System.Linq;

namespace RevengeOfThePancakes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                Console.WriteLine("Enter number of test cases");
                HandlePancakeStringsInteractive(GetTestCases());
            }
            else
            {
                HandlePancakeStrings(ParseArgs(args));
            }
        }

        // Because dotnet doesn't like a single/double dash without being quoted
        // Let's allow you to pass in a single string of everything
        private static string[] ParseArgs(string[] args)
        {
            var parsedArgs = new List<string>();
            foreach (var arg in args)
            {
                if (arg.Contains(" "))
                {
                    arg.Split(" ").ToList().ForEach(a => parsedArgs.Add(a));
                }
            }

            return parsedArgs.ToArray();
        }

        private static void HandlePancakeStrings(string[] args)
        {
            if (! int.TryParse(args[0], out var testCases)) 
                throw new Exception("Invalid test cases provided, must be an integer.");
            
            var pancakeSorter = new PancakeSorter();
            
            // Start at index 1 because that's the test cases int
            // Also only do as many testCases as provided, if they provide more ignore it
            for (var i = 1; i <= testCases && i < args.Length; i++)
            {
                var (_, numberOfExecutions) = pancakeSorter.SortRecursive(args[i]);
                Console.WriteLine($"Case #{i}: {numberOfExecutions}");
            }
        }

        private static void HandlePancakeStringsInteractive(int testCases)
        {
            var pancakeSorter = new PancakeSorter();
            
            Console.WriteLine("Begin pancake string input");
            for (var i = 0; i < testCases; i++)
            {
                var pancakeString = Console.ReadLine()?.Trim();
                while (!new InputValidator().IsValidPancakeString(pancakeString))
                {
                    Console.WriteLine("Invalid pancake string, try again. (only + and - are allowed)");
                    pancakeString = Console.ReadLine()?.Trim();
                }
                
                var (_, numberOfExecutions) = pancakeSorter.Sort(pancakeString);
                Console.WriteLine($"Case #{i + 1}: {numberOfExecutions}");
            }
        }
        
        private static int GetTestCases()
        {
            if (! int.TryParse(Console.ReadLine(), out var numberOfTestCases))
            {
                Console.WriteLine("Must provide an integer for a test case, try again.");
                return GetTestCases();
            }

            return numberOfTestCases;
        }
    }
}