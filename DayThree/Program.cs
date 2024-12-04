using static System.Net.Mime.MediaTypeNames;

namespace Day3;

internal class Program
{
    static void Main(string[] args)
    {
        // Split the string at do() and don't() then concat the string.
        string[] textSplit = File.ReadAllText($@"{Environment.CurrentDirectory}/data/input.txt")
            .Split("do()");


        var textQuery =
            from text in textSplit
            where text.StartsWith('(')
            select text;



            .Split("mul")
            .Select(static text => text.Length >= 9 ? text[..9] : text)
            .Where(static text => text.StartsWith('(') && text.Contains(')'))
            .Select(static text => text[..text.IndexOf(')')])
            .Select(static text => text.Trim('('))
            .ToArray();

        int total = 0;
        foreach (string text in textSplit)
        {
            string[] numberStrs = text.Split(',');
            if (int.TryParse(numberStrs[0], out int leftNum ) && int.TryParse(numberStrs[1], out int rightNum))
            {
                Console.WriteLine(leftNum + " " + rightNum);
                if (leftNum > 999 || rightNum > 999)
                {
                    break;
                }
                total += leftNum * rightNum;
            }
        }
        // 166357705
        Console.WriteLine(total);
    }
}
