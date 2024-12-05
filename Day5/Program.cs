using System;

namespace Day5;

internal class Program
{
    static void Main(string[] args)
    {
        string inputData = File.ReadAllText($@"{Environment.CurrentDirectory}/data/test_input.txt");
        string[] inputArray = inputData.Split(Environment.NewLine);

        SplitArray(inputArray, string.Empty, out string[] first, out string[] second);
        foreach (string text in first)
        {
            Console.WriteLine(text);
        }
        Console.WriteLine("SECOND");
        foreach (string text in second)
        {
            Console.WriteLine(text);
        }
    }

    private static void SplitArray(string[] input, string delimiter, out string[] first, out string[] second)
    {
        int index = Array.IndexOf(input, delimiter);
        first = input.Take(index - 1).ToArray();
        second = input.Skip(index + 1).ToArray();
    }
}
