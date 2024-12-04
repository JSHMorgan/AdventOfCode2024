using System.Text;

namespace Day4;

internal class Program
{ 
    private static void Main(string[] args)
    {
        string inputData = File.ReadAllText($@"{Environment.CurrentDirectory}/data/test_input.txt");
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

    private static bool CheckDown(int index, char[] inputRow)
    {
        return CheckRight(index, inputRow);
    }

    private static bool CheckRight(int index, char[] inputRow)
    {
        if (index + 3 >= inputRow.Length)
        {
            return false;
        }
        StringBuilder builder = new();
        for (int i = index; i < index + 4; i++)
        {
            builder.Append(inputRow[i]);
        }
        return builder.Equals("XMAS");
    }

    private static bool CheckUp(int index, char[] inputRow)
    {
        return CheckLeft(index, inputRow);
    }

    private static bool CheckLeft(int index, char[] inputRow)
    {
        if (index - 3 < 0)
        {
            return false;
        }
        StringBuilder builder = new();
        for (int i = index - 3; i < index + 1; i++)
        {
            builder.Append(inputRow[i]);
        }
        return builder.Equals("XMAS");
    }

    private static bool CheckTopLeftDiagonal(int index, char[] inputDiagonal)
    {
        return CheckLeft(index, inputDiagonal);
    }

    private static bool CheckBottomRightDiagonal(int index, char[] inputDiagonal)
    {
        return CheckRight(index, inputDiagonal);
    }

    private static bool CheckBottomLeftDiagonal(int index, char[] inputDiagonal)
    {
        return CheckRight(index, inputDiagonal);
    }

    private static bool CheckTopRightDiagonal(int index, char[] inputDiagonal)
    {
        return CheckRight(index, inputDiagonal);
    }
}
