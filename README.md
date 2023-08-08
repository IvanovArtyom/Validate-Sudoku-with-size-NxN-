## Description:
Given a Sudoku data structure with size ```NxN, N > 0 and √N == integer```, write a method to validate if it has been filled out correctly.

The data structure is a multi-dimensional Array, i.e:
```
[
  [7,8,4,  1,5,9,  3,2,6],
  [5,3,9,  6,7,2,  8,4,1],
  [6,1,2,  4,3,8,  7,5,9],
  
  [9,2,8,  7,1,5,  4,6,3],
  [3,5,7,  8,4,6,  1,9,2],
  [4,6,1,  9,2,3,  5,8,7],
  
  [8,7,6,  3,9,4,  2,1,5],
  [2,4,3,  5,6,1,  9,7,8],
  [1,9,5,  2,8,7,  6,3,4]
]
```
### Rules for validation
- Data structure dimension: ```NxN``` where ```N > 0``` and ```√N == integer```
- Rows may only contain integers: ```1..N (N included)```
- Columns may only contain integers: ```1..N (N included)```
- *'Little squares'* (```3x3``` in example above) may also only contain integers: ```1..N (N included)```
### My solution
```C#
using System;
using System.Linq;

class Sudoku
{
    private readonly int[][] sudokuData;

    public Sudoku(int[][] sudokuData)
    {
        this.sudokuData = sudokuData;
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
        return array.Length == array.Distinct().Count()
            && array.All(x => x > 0 && x <= array.Length);
    }
}
```
