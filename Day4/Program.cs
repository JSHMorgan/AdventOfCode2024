using System.Text;

namespace Day4;

internal class Program
{ 
    private static void Main(string[] args)
    {
        string inputData = File.ReadAllText($@"{Environment.CurrentDirectory}/data/input.txt");
        string[] inputArray = inputData.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        char[,] inputChars = ConvertStringArrayToChars(inputArray);

        ExerciseOne(inputChars);
        ExerciseTwo(inputChars);
    }

    private static void ExerciseOne(char[,] inputChars)
    {
        WordSearch wordSearch = new(inputChars);
        WordSearchSolver solver = new(wordSearch);
        int counter = solver.GetWordCount("XMAS");
        Console.WriteLine(counter);
    }

    private static void ExerciseTwo(char[,] inputChars)
    {
        int crossMasCounter = 0;
        // An A on the edges of the grid cannot give an answer.
        for (int row = 1; row < inputChars.GetLength(0) - 1; row++)
        {
            for (int column = 1; column < inputChars.GetLength(1) - 1; column++)
            {
                char a = inputChars[row, column];
                if (a != 'A')
                {
                    continue;
                }
                char[] diagonalMasArray = { inputChars[row - 1, column - 1], a, inputChars[row + 1, column + 1] };
                string? diagonalMas = new(diagonalMasArray);

                char[] antiDiagonalMasArray = { inputChars[row + 1, column - 1], a, inputChars[row - 1, column + 1] };
                string? antiDiagonalMas = new(antiDiagonalMasArray);

                if ((diagonalMas == "MAS" || diagonalMas == "SAM")
                && (antiDiagonalMas == "MAS" || antiDiagonalMas == "SAM"))
                {
                    crossMasCounter++;
                }
            }
        }
        Console.WriteLine(crossMasCounter);
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
