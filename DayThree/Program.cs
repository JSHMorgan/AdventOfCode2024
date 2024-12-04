using System.Text.RegularExpressions;

namespace Day3;

internal class Program
{
    static void Main(string[] args)
    {
        // Split the string at do() and don't() then concat the string.
        string inputData = File.ReadAllText($@"{Environment.CurrentDirectory}/data/input.txt");

        ExerciseOne(inputData);
        ExerciseTwo(inputData);
    }

    private static void ExerciseOne(string inputData)
    {
        IEnumerable<string> mulStrings = GetMulStrings(inputData);

        int total = GetTotal(mulStrings);
        Console.WriteLine(total);
    }
    private static void ExerciseTwo(string inputData)
    {
        const string pattern = @"(?=do\(\)|don't\(\))";
        string[] result = Regex.Split(inputData, pattern).Where(text => !text.StartsWith("don't()")).ToArray();
        string doResults = string.Join("", result);
        IEnumerable<string> mulStrings = GetMulStrings(doResults);

        int total = GetTotal(mulStrings);
        Console.WriteLine(total);
    }

    private static IEnumerable<string> GetMulStrings(string inputData)
    {
        return inputData.Split("mul")
            .Select(static text => text.Length >= 9 ? text[..9] : text)
            .Where(static text => text.StartsWith('(') && text.Contains(')'))
            .Select(static text => text[..text.IndexOf(')')])
            .Select(static text => text.Trim('('));
    }

    private static int GetTotal(IEnumerable<string> mulStrings)
    {
        int total = 0;
        foreach (string text in mulStrings)
        {
            string[] numberStrs = text.Split(',');
            if (!int.TryParse(numberStrs[0], out int leftNum) 
            || !int.TryParse(numberStrs[1], out int rightNum) 
            || leftNum > 999 || rightNum > 999)
            {
                continue;
            }

            total += leftNum * rightNum;
        }
        return total;
    }
}
