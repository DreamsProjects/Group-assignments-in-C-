using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy_Sudoku
{
    class Sudoku
    {
        private int[,] sudokuCells;

        // Konstruktor, skriv in alla givna siffror i arrayen
        public Sudoku(string sudokuProblem)
        {
            sudokuCells = new int[9, 9];
            for (int i = 0; i < sudokuProblem.Length; i++)
            {
                int row = i / 9;
                int column = i % 9;
                if ((row < 9) && (column < 9))
                {
                    this.sudokuCells[row, column] = int.Parse(sudokuProblem.Substring(i, 1));
                }
            }
        }

        // Denna metod försöker lösa sudokut
        internal bool Solve()
        {
            bool anyNumberWritten;

            do
            {
                anyNumberWritten = false;
                for (int row = 0; row < 9; row++)
                {
                    for (int column = 0; column < 9; column++)
                    {
                        if (sudokuCells[row, column] == 0)   // Om cellen är tom
                        {
                            List<int> possibleValues = CalculatePossibleNumbers(row, column);

                            if (possibleValues.Count == 1)    // Om exakt en siffra är möjlig i  en cell 
                            {
                                // Skriv in den enda möjliga siffran i cellen
                                sudokuCells[row, column] = possibleValues[0];
                                anyNumberWritten = true;
                            }
                        }
                    }
                }

            }

            while (anyNumberWritten); // Fortsätt i loopen om minst en siffra blev inskriven          
            return CheckSudokuSolved();
        }

        // Denna metod skriver ut Sudokut på konsolen
        internal void PrintBoard()
        {
            for (int row = 0; row < 9; row++)
            {
                if (row % 3 == 0)
                {
                    for (int i = 0; i < 25; i++)
                    {
                        Console.Write("-");
                    }
                    Console.WriteLine();
                }

                for (int column = 0; column < 9; column++)
                {
                    if (column % 3 == 0)
                    {
                        Console.Write("| ");
                    }
                    Console.Write(sudokuCells[row, column] + " ");
                }

                Console.Write("|");
                Console.WriteLine();
            }

            for (int i = 0; i < 25; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }

        // Denna metod returnerar en lista på dom siffror som är logiskt möjliga i en viss cell
        private List<int> CalculatePossibleNumbers(int row, int col)
        {
            List<int> rowNumbers = GetNumbersInRow(row);
            List<int> colNumbers = GetNumbersInColumn(col);
            List<int> boxNumbers = GetNumbersInBox(row, col);

            List<int> possibleNumbers = new List<int>();

            for (int i = 1; i < 10; i++)
            {
                // Om denna siffra varken finns i cellens rad,cellens kolumn eller cellens ruta
                if (!(rowNumbers.Contains(i) || colNumbers.Contains(i) || boxNumbers.Contains(i)))
                {
                    possibleNumbers.Add(i);
                }
            }

            return possibleNumbers;
        }

        private bool CheckNineIntegers(int[] nineIntegers)
        {
            for (int i = 1; i < 10; i++)
            {
                if (!(nineIntegers.Contains(i)))
                {
                    return false;
                }
            }
            return true;
        }

        // Denna metod kontrollerar om Sudokut är löst
        private bool CheckSudokuSolved()
        {
            for (int row = 0; row < 9; row++)
            {
                int[] numbers = new int[9];
                for (int col = 0; col < 9; col++)
                {
                    numbers[col] = sudokuCells[row, col];
                }
                if (!CheckNineIntegers(numbers))
                {
                    return false;
                }
            }

            for (int col = 0; col < 9; col++)
            {
                int[] numbers = new int[9];
                for (int row = 0; row < 9; row++)
                {
                    numbers[row] = sudokuCells[row, col];
                }
                if (!CheckNineIntegers(numbers))
                {
                    return false;
                }
            }

            for (int boxRow = 0; boxRow < 3; boxRow++)
            {
                for (int colRow = 0; colRow < 3; colRow++)
                {
                    int[] numbers = new int[9];
                    for (int index = 0; index < 9; index++)
                    {
                        int row = boxRow * 3 + index / 3;
                        int col = colRow * 3 + index % 3;
                        numbers[index] = sudokuCells[row, col];
                    }
                    if (!CheckNineIntegers(numbers))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        // Denna metod returnerar en lista på dom siffror som är inskrivna i en viss rad
        private List<int> GetNumbersInRow(int row)
        {
            List<int> numbersInRow = new List<int>();
            for (int col = 0; col < 9; col++)
            {
                int number = sudokuCells[row, col];
                if (number > 0)
                {
                    numbersInRow.Add(number);
                }
            }

            return numbersInRow;
        }

        // Denna metod returnerar en lista på dom siffror som är inskrivna i en viss kolumn
        private List<int> GetNumbersInColumn(int col)
        {
            List<int> numbersInCol = new List<int>();
            for (int row = 0; row < 9; row++)
            {
                int number = sudokuCells[row, col];
                if (number > 0)
                {
                    numbersInCol.Add(number);
                }
            }

            return numbersInCol;
        }

        // Denna metod returnerar en lista på dom siffror som är inskrivna i samma ruta
        private List<int> GetNumbersInBox(int row, int col)
        {
            List<int> numbersInBox = new List<int>();

            int startRow = row / 3;
            int startCol = col / 3;

            for (int boxRow = startRow * 3; boxRow < (startRow + 1) * 3; boxRow++)
            {
                for (int boxCol = startCol * 3; boxCol < (startCol + 1) * 3; boxCol++)
                {
                    int number = sudokuCells[boxRow, boxCol];
                    if (number > 0)
                    {
                        numbersInBox.Add(number);
                    }
                }
            }

            return numbersInBox;
        }
    }
}

