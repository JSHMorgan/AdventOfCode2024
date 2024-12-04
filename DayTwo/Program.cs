namespace Day2;

internal record Report(List<int> Levels);

internal class Program
{
    private static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines($@"{Environment.CurrentDirectory}/data/input.txt");

        List<Report> reports = [];

        foreach (string line in lines)
        {
            int[] numbers = line.Split(' ').Select(int.Parse).ToArray();
            reports.Add(new Report([.. numbers]));
        }

        ExerciseOne(reports);
        ExerciseTwo(reports);
    }

    private static void ExerciseOne(List<Report> reports)
    {
        int safeReportCount = 0;
        foreach (Report report in reports)
        {
            if (IsReportSafe(false, report))
            {
                safeReportCount++;
            }
        }
        Console.WriteLine(safeReportCount);
    }

    private static bool IsReportSafe(bool isExerciseTwo, Report report)
    {
        int problemDampererCount = 0;
        int[] levels = [.. report.Levels];
        bool isAscending = levels[0] < levels[1];
        for (int i = 0; i < report.Levels.Count - 1; i++)
        {
            int number = report.Levels[i];
            int nextNumber = report.Levels[i + 1];

            if (number == nextNumber || Math.Abs(number - nextNumber) > 3
            || isAscending && number > nextNumber
            || !isAscending && number < nextNumber)
            {
                if (isExerciseTwo && problemDampererCount++ == 0)
                {
                    i--;
                    report.Levels.Remove(number);
                    continue;
                }
                return false;
            }
        }
        return true;
    }

    private static void ExerciseTwo(List<Report> reports)
    {
        int safeReportCount = 0;
        foreach (Report report in reports)
        {
            if (IsReportSafe(true, report))
            {
                safeReportCount++;
            }
        }
        Console.WriteLine(safeReportCount);
    }
}
