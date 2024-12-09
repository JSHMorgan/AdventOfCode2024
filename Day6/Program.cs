namespace Day6;
internal class Program
{
    private readonly static char[] GuaradChars = ['^', '>', '<', 'v'];
    private readonly static char ObstacleChar = '#';
    static void Main(string[] args)
    {
        string inputData = File.ReadAllText($@"{Environment.CurrentDirectory}/data/test_input.txt");
        string[] inputArray = inputData.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        char[,] inputChars = ConvertStringArrayToChars(inputArray, out (int x, int y) guardPos);

        int movement = 0;
        int currentMovement = 0;
        while (currentMovement != -1)
        {

        }
    }

    private static char[,] ConvertStringArrayToChars(string[] inputArray, out (int, int) guardPos)
    {
        guardPos = default;
        char[,] chars = new char[inputArray.Length, inputArray[0].Length];
        for (int i = 0; i < inputArray.Length; i++)
        {
            string item = inputArray[i];
            for (int j = 0; j < item.Length; j++)
            {
                chars[i, j] = item[j];
                if (GuaradChars.Contains(item[j]))
                {
                    guardPos = (i, j);
                }
            }
        }
        return chars;
    }

    private static int MoveGuard(ref char[,] inputChars, ref (int x, int y) guardPos)
    {
        switch (inputChars[guardPos.x, guardPos.y])
        {
            case '^':
                return MoveUp(ref inputChars, ref guardPos);
            case '>': 
                break;
            case '<':
                break;
            case 'v':
                break;

            default:
                break;
        }
        return 0;
    }

    private static int MoveUp(ref char[,] inputChars, ref (int x, int y) guardPos)
    {
        if (guardPos.y - 1 == ObstacleChar)
        {
            inputChars[guardPos.x, guardPos.y] = '>';
            return 0;
        }

        return 1;
    }

    private static void MoveDown()
    {
    }

    private static void MoveLeft()
    {
    }

    private static void MoveRight()
    {
    }
}
