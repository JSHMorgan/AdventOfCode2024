namespace Day4;

internal record WordSearch(char[,] Letters)
{
    public int RowLength => Letters.GetLength(0);

    public int ColumnLength => Letters.GetLength(1);

    public char[] GetRow(int index)
    {
        char[] row = new char[RowLength];
        for (int i = 0; i < row.Length; i++)
        {
            row[i] = Letters[index, i];
        }
        return row;
    }

    public char[] GetColumn(int index)
    {
        char[] column = new char[ColumnLength];
        for (int i = 0; i < column.Length; i++)
        {
            column[i] = Letters[i, index];
        }
        return column;
    }
    public bool TryGetLetter(int row, int column, out char c)
    {
        c = default;
        if (row < 0 || row > RowLength - 1)
        {
            return false;
        }
        if (column < 0 || column > ColumnLength - 1)
        {
            return false;
        }
        c = Letters[row, column];
        return true;
    }

    public char[] GetDiagonalFromPosition(int row, int column)
    {
        List<char> chars = [];
        int tempRow = row - 1;
        int tempColumn = column - 1;
        while (TryGetLetter(tempRow, tempColumn, out char c))
        {
            chars.Add(c);
            tempRow--;
            tempColumn--;
        }
        chars.Reverse();
        chars.Add(Letters[row, column]);

        tempRow = row + 1;
        tempColumn = column + 1;
        while (TryGetLetter(tempRow, tempColumn, out char c))
        {
            chars.Add(c);
            tempRow++;
            tempColumn++;
        }
        return [.. chars];
    }

    public char[] GetAntiDiagonalFromPosition(int row, int column)
    {
        List<char> chars = [];
        int tempRow = row - 1;
        int tempColumn = column + 1;
        while (TryGetLetter(tempRow, tempColumn, out char c))
        {
            chars.Add(c);
            tempRow--;
            tempColumn++;
        }
        chars.Reverse();
        chars.Add(Letters[row, column]);

        tempRow = row + 1;
        tempColumn = column - 1;
        while (TryGetLetter(tempRow, tempColumn, out char c))
        {
            chars.Add(c);
            tempRow++;
            tempColumn--;
        }
        return [.. chars];
    }
}