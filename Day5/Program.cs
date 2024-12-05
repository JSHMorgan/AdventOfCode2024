using System;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;
using QuickGraph;

namespace Day5;

internal class Program
{
    static void Main(string[] args)
    {
        string inputData = File.ReadAllText($@"{Environment.CurrentDirectory}/data/input.txt");
        string[] inputArray = inputData.Split(Environment.NewLine);

        SplitArray(inputArray, string.Empty, out string[] orderingRules, out string[] pageLines);
        Dictionary<int, HashSet<int>> orderingNumbers = GetOrderingNumbers(orderingRules);

        List<List<int>> incorrectPageLines = ExerciseOne(pageLines, orderingNumbers);
        ExerciseTwo(incorrectPageLines, orderingNumbers);
    }

    private static void SplitArray(string[] input, string delimiter, out string[] first, out string[] second)
    {
        int index = Array.IndexOf(input, delimiter);
        first = input.Take(index - 1).ToArray();
        second = input.Skip(index + 1).ToArray();

    }

    private static List<List<int>> ExerciseOne(string[] pageLines, Dictionary<int, HashSet<int>> orderingNumbers)
    {
        int midPointSum = 0;
        List<List<int>> incorrectPageLines = [];
        foreach (string pageLine in pageLines)
        {
            List<int> pages = pageLine.Split(',').Select(int.Parse).ToList();

            if (CheckIfPageListValid(pages, orderingNumbers))
            {
                midPointSum += pages[pages.Count / 2];
            }
            else
            {
                incorrectPageLines.Add(pages);
            }
        }
        Console.WriteLine(midPointSum);
        return incorrectPageLines;
    }

    private static Dictionary<int, HashSet<int>> GetOrderingNumbers(string[] orderingRules)
    {
        Dictionary<int, HashSet<int>> orderingNumbers = [];
        for (int i = 0; i < orderingRules.Length; i++)
        {
            string[] numbers = orderingRules[i].Split("|");
            int leftNum = int.Parse(numbers[0]);
            int rightNum = int.Parse(numbers[1]);

            if (orderingNumbers.TryGetValue(leftNum, out HashSet<int>? value))
            {
                value.Add(rightNum);
            }
            else
            {
                orderingNumbers.Add(leftNum, new HashSet<int>(rightNum));
            }
        }
        return orderingNumbers;
    }

    private static bool CheckIfPageListValid(List<int> pageLine, Dictionary<int, HashSet<int>> orderingNumbers)
    {
        foreach (int page in pageLine)
        {
            for (int i = 0; i < pageLine.IndexOf(page); i++)
            {
                int previousNumber = pageLine[i];
                if (orderingNumbers.TryGetValue(page, out HashSet<int>? result) && result != null && result.Contains(previousNumber))
                {
                    return false;
                }
            }
        }
        return true;
    }

    private static void ExerciseTwo(List<List<int>> incorrectPageLines, Dictionary<int, HashSet<int>> orderingNumbers)
    {
        foreach (List<int> pageLine in incorrectPageLines)
        {
            foreach (int page in pageLine)
            {
                int previousNumber = pageLine[i];
                if (orderingNumbers.TryGetValue(page, out HashSet<int>? result) && result != null && result.Contains(previousNumber))
                { 
                }
            }
        }
    }
}
