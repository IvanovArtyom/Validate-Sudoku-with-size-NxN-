using System;
using System.Linq;

class Sudoku
{
    private readonly int[][] sudokuData;

    public Sudoku(int[][] sudokuData)
    {
        this.sudokuData = sudokuData;
    }

    public static void Main()
    {
        Sudoku goodSudoku = new(new int[][] {
            new int[] { 7,8,4, 1,5,9, 3,2,6 },
            new int[] { 5,3,9, 6,7,2, 8,4,1 },
            new int[] { 6,1,2, 4,3,8, 7,5,9 },

            new int[] { 9,2,8, 7,1,5, 4,6,3 },
            new int[] { 3,5,7, 8,4,6, 1,9,2 },
            new int[] { 4,6,1, 9,2,3, 5,8,7 },

            new int[] { 8,7,6, 3,9,4, 2,1,5 },
            new int[] { 2,4,3, 5,6,1, 9,7,8 },
            new int[] { 1,9,5, 2,8,7, 6,3,4 } });

        // Test
        var t = goodSudoku.IsValid();
        // ...should return true
    }

    public bool IsValid()
    {
        int size = sudokuData.GetLength(0);

        // Rows check
        for (int i = 0; i < size; i++)
        {
            if (sudokuData[i].Length != size || !IsValidArr(sudokuData[i]))
                return false;
        }

        int[] arr = new int[size];

        // Columns check
        for (int j = 0; j < size; j++)
        {
            for (int i = 0; i < size; i++)
                arr[i] = sudokuData[i][j];

            if (!IsValidArr(arr))
                return false;
        }

        int littleSize = (int)Math.Sqrt(size);
        int count = 0;

        // Little squares check
        for (int i = 0; i < size; i += littleSize)
        {
            for (int j = 0; j < size; j += littleSize)
            {
                for (int row = i; row < i + littleSize; row++)
                {
                    for (int column = j; column < j + littleSize; column++)
                        arr[count++] = sudokuData[row][column];
                }

                if (!IsValidArr(arr))
                    return false;

                count = 0;
            }
        }

        return true;
    }

    public static bool IsValidArr(int[] array)
    {
        return array.Length == array.Distinct().Count() && array.All(x => x > 0 && x <= array.Length);
    }
}