using System.Text;
using System;

namespace Day4;

internal class WordSearchSolver(WordSearch Search)
{
    public Dictionary<string, int> GetWordsCount(string[] words)
    {
        Dictionary<string, int> wordDictionary = [];
        foreach (string word in words)
        {
            wordDictionary.Add(word, GetWordCount(word));
        }
        return wordDictionary;
    }

    public int GetWordCount(string word)
    {
        int wordCount = 0;

        for (int i = 0; i < Search.RowLength; i++)
        {
            wordCount += GetRowWordCount(i, word);
        }

        for (int i = 0; i < Search.ColumnLength; i++)
        {
            wordCount += GetColumnWordCount(i, word);
        }

        for (int i = 0; i < Search.RowLength; i++)
        {
            wordCount += GetDiagonalWordCount(true, Search.RowLength - i - 1, 0, word);
        }

        // Start from 1 or you get a duplicate at (0, 0).
        for (int i = 1; i < Search.ColumnLength; i++)
        {
            wordCount += GetDiagonalWordCount(true, 0, i, word);
        }

        for (int i = 0; i < Search.ColumnLength; i++)
        {
            wordCount += GetDiagonalWordCount(false, 0, i, word);
        }

        // Start from 1 or you get a duplicate at (0, 0).
        for (int i = 1; i < Search.ColumnLength; i++)
        {
            wordCount += GetDiagonalWordCount(false, Search.ColumnLength - 1, i, word);
        }

        return wordCount;
    }

    

    public int GetRowWordCount(int row, string word)
    {
        char[] reverseWordArray = word.ToCharArray();
        Array.Reverse(reverseWordArray);
        string reverseWord = new(reverseWordArray);

        int counter = 0;
        char[] inputRow = Search.GetRow(row);
        for (int column = 0; column < Search.RowLength - word.Length + 1; column++)
        {
            StringBuilder builder = new();
            for (int i = 0; i < word.Length; i++)
            {
                _ = builder.Append(inputRow[column + i]);
            }
            if (builder.ToString() == word || builder.ToString() == reverseWord)
            {
                counter++;
            }
        }
        return counter;
    }

    public int GetColumnWordCount(int column, string word)
    {
        char[] reverseWordArray = word.ToCharArray();
        Array.Reverse(reverseWordArray);
        string reverseWord = new(reverseWordArray);

        int counter = 0;
        char[] inputRow = Search.GetColumn(column);
        for (int row = 0; row < Search.RowLength - word.Length + 1; row++)
        {
            StringBuilder builder = new();
            for (int i = 0; i < word.Length; i++)
            {
                builder.Append(inputRow[row + i]);
            }
            if (builder.ToString() == word || builder.ToString() == reverseWord)
            {
                counter++;
            }
        }
        return counter;
    }

    public int GetDiagonalWordCount(bool isDiagonal, int row, int column, string word)
    {
        char[] reverseWordArray = word.ToCharArray();
        Array.Reverse(reverseWordArray);
        string reverseWord = new(reverseWordArray);

        int counter = 0;

        char[] inputDiagonal = isDiagonal ? Search.GetDiagonalFromPosition(row, column) : Search.GetAntiDiagonalFromPosition(row, column);

        for (int diagonal = 0; diagonal < inputDiagonal.Length - word.Length + 1; diagonal++)
        {
            StringBuilder builder = new();
            for (int i = 0; i < word.Length; i++)
            {
                builder.Append(inputDiagonal[diagonal + i]);
            }
            if (builder.ToString() == word || builder.ToString() == reverseWord)
            {
                counter++;
            }
        }
        return counter;
    }
}
