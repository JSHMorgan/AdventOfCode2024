using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5;
internal class FoundSolution
{
    public static int PartOne(string input)
    {
        (string[][] updates, Comparer<string> comparer) = Parse(input);
        return updates
            .Where(pages => Sorted(pages, comparer))
            .Sum(GetMiddlePage);
    }

    public static int PartTwo(string input)
    {
        (string[][] updates, Comparer<string> comparer) = Parse(input);
        return updates
            .Where(pages => !Sorted(pages, comparer))
            .Select(pages => pages.OrderBy(page => page, comparer).ToArray())
            .Sum(GetMiddlePage);
    }

    private static (string[][] updates, Comparer<string>) Parse(string input)
    {
        string[] parts = input.Split(Environment.NewLine + Environment.NewLine);

        HashSet<string> ordering = new(parts[0].Split(Environment.NewLine));
        Comparer<string> comparer = Comparer<string>.Create((leftPage, rightPage) => ordering.Contains(leftPage + "|" + rightPage) ? -1 : 1);

        string[][] updates = parts[1].Split(Environment.NewLine).Select(line => line.Split(",")).ToArray();
        return (updates, comparer);
    }

    private static int GetMiddlePage(string[] nums)
    {
        return int.Parse(nums[nums.Length / 2]);
    }

    private static bool Sorted(string[] pages, Comparer<string> comparer)
    {
        return Enumerable.SequenceEqual(pages, pages.OrderBy(x => x, comparer));
    }
}
