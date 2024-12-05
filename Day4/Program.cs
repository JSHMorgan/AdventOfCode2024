using System.Text;

namespace Day4;

internal class Program
{ 
    private static void Main(string[] args)
    {
        string inputData = File.ReadAllText($@"{Environment.CurrentDirectory}/data/input.txt");
        string[] inputArray = inputData.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        char[,] inputChars = ConvertStringArrayToChars(inputArray);
        Wordsearch wordSearch = new(inputChars);
        WordSearchSolver solver = new(wordSearch, "XMAS");
        int counter = solver.GetWordCount();
        Console.WriteLine(counter);
    }

    private static char[,] ConvertStringArrayToChars(string[] inputArray)
    {
        char[,] chars = new char[inputArray.Length, inputArray[0].Length];
        for (int i = 0; i < inputArray.Length; i++)
        {
            string item = inputArray[i];
            for (int j = 0; j < item.Length; j++)
            {
                chars[i, j] = item[j];
            }
        }
        return chars;
    }
}
