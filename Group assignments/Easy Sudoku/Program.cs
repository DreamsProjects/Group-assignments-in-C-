using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy_Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hej! Det här programmet löser enkla Sudoku problem");
            Console.WriteLine("\nSkriv in ditt Sudoku problem genom att ange en siffra(1-9) för varje cell");
            Console.WriteLine("Varje tom cell ska skrivas som siffran 0\n");
            Sudoku game = new Sudoku(InputSudoku());

            bool result = game.Solve();
            Console.WriteLine();

            if (result)
            {
                Console.WriteLine("Det gick att lösa sudokut:");
                game.PrintBoard();
            }

            else
            {
                Console.WriteLine("Tyvärr. Det gick inte att lösa sudokut: ");
                game.PrintBoard(); //För att skriva ut snyggt även om det inte gick att lösa
            }

            Console.WriteLine();

            Console.ReadLine();
        }

        // Den här metoden läser in ett Sudoku från Consolen 
        private static string InputSudoku()
        {
            string inputGame = "";
            for (int i = 1; i < 10; i++)
            {
                while (true)
                {
                    Console.Write("Skriv in siffror för dom 9 positionerna i rad {0}: ", i);
                    string inputRow = Console.ReadLine();

                    if (!int.TryParse(inputRow, out int num))
                    {
                        Console.WriteLine("Du får bara skriva in siffror");
                    }
                    else if (inputRow.Length != 9)
                    {
                        Console.WriteLine("Du måste skriva in 9 siffror för varje rad");
                    }
                    else
                    {
                        inputGame += inputRow;
                        break;
                    }
                }
            }
            return inputGame;
        }
    }
}

