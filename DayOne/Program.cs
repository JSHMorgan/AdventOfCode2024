namespace Day1;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines($@"{Environment.CurrentDirectory}/data/input.txt");
        List<int> leftNumbers = [], rightNumbers = [];

        foreach (string line in lines)
        {
            string[] numbers = line.Split("   ");
            leftNumbers.Add(int.Parse(numbers[0]));
            rightNumbers.Add(int.Parse(numbers[1]));
        }

        ExerciseOne(leftNumbers, rightNumbers);
        ExerciseTwo(leftNumbers, rightNumbers);
    }

    private static void ExerciseOne(List<int> leftNumbers, List<int> rightNumbers)
    {
        ArgumentNullException.ThrowIfNull(leftNumbers);
        ArgumentNullException.ThrowIfNull(rightNumbers);

        leftNumbers.Sort();
        rightNumbers.Sort();

        int distance = 0;
        for (int i = 0; i < leftNumbers.Count; i++)
        {
            distance += Math.Abs(leftNumbers[i] - rightNumbers[i]);
        }
        Console.WriteLine(distance);
    }
    private static void ExerciseTwo(List<int> leftNumbers, List<int> rightNumbers)
    {
        ArgumentNullException.ThrowIfNull(leftNumbers);
        ArgumentNullException.ThrowIfNull(rightNumbers);

        Dictionary<int, int> similarityScores = [];

        int similarityScore = 0;
        foreach (int number in leftNumbers)
        {
            if (similarityScores.TryGetValue(number, out int value))
            {
                similarityScore += value;
            }
            else if (rightNumbers.Contains(number)) 
            {
                int count = rightNumbers.Where(x => x == number).Count();
                similarityScores[number] = count * number;
                similarityScore += count * number;
            }
        }
        Console.WriteLine(similarityScore);
    }
}
