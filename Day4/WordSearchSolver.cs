using System.Text;
using System;

namespace Day4;

internal record WordSearchSolver(Wordsearch Search, string Word)
{
    public int GetWordCount()
    {
        int counter = 0;

        for (int i = 0; i < Search.RowLength; i++)
        {
            counter += GetRowWordCount(i);
        }

        for (int i = 0; i < Search.ColumnLength; i++)
        {
            counter += GetColumnWordCount(i);
        }
        
        for (int i = 0; i < Search.DiagonalLength; i++)
        {
            counter += GetTopLeftDiagonalWordCount(i, i);
        }

        for (int i = 0; i < Search.DiagonalLength; i++)
        {
            counter += GetTopRightDiagonalWordCount(i, Search.DiagonalLength - 1 - i);
        }
        return counter;
    }
    public int GetRowWordCount(int row)
    {
        char[] reverseWordArray = Word.ToCharArray();
        Array.Reverse(reverseWordArray);
        string reverseWord = new(reverseWordArray);

        int counter = 0;
        char[] inputRow = Search.GetRow(row);
        for (int column = 0; column < Search.RowLength - Word.Length + 1; column++)
        {
            StringBuilder builder = new();
            for (int i = 0; i < Word.Length; i++)
            {
                _ = builder.Append(inputRow[column + i]);
            }
            if (builder.ToString() == Word || builder.ToString() == reverseWord)
            {
                counter++;
            }
        }
        return counter;
    }

    public int GetColumnWordCount(int column)
    {
        char[] reverseWordArray = Word.ToCharArray();
        Array.Reverse(reverseWordArray);
        string reverseWord = new(reverseWordArray);

        int counter = 0;
        char[] inputRow = Search.GetColumn(column);
        for (int row = 0; row < Search.RowLength - Word.Length + 1; row++)
        {
            StringBuilder builder = new();
            for (int i = 0; i < Word.Length; i++)
            {
                builder.Append(inputRow[row + i]);
            }
            if (builder.ToString() == Word || builder.ToString() == reverseWord)
            {
                counter++;
            }
        }
        return counter;
    }

    public int GetTopLeftDiagonalWordCount(int row, int column)
    {
        char[] reverseWordArray = Word.ToCharArray();
        Array.Reverse(reverseWordArray);
        string reverseWord = new(reverseWordArray);

        int counter = 0;
        char[] inputDiagonal = Search.GetBottomLeftDiagonalFromLetter(row, column);
        for (int diagonal = 0; diagonal < inputDiagonal.Length - Word.Length + 1; diagonal++)
        {
            StringBuilder builder = new();
            for (int i = 0; i < Word.Length; i++)
            {
                builder.Append(inputDiagonal[diagonal + i]);
            }
            if (builder.ToString() == Word || builder.ToString() == reverseWord)
            {
                counter++;
            }
        }
        return counter;
    }

    public int GetTopRightDiagonalWordCount(int row, int column)
    {
        char[] reverseWordArray = Word.ToCharArray();
        Array.Reverse(reverseWordArray);
        string reverseWord = new(reverseWordArray);

        int counter = 0;
        char[] inputDiagonal = Search.GetTopLeftDiagonalFromLetter(row, column);
        for (int diagonal = 0; diagonal < inputDiagonal.Length - Word.Length + 1; diagonal++)
        {
            StringBuilder builder = new();
            for (int i = 0; i < Word.Length; i++)
            {
                builder.Append(inputDiagonal[diagonal + i]);
            }
            if (builder.ToString() == Word || builder.ToString() == reverseWord)
            {
                counter++;
            }
        }
        return counter;
    }
}
