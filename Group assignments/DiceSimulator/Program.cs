using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random(); 
            int sum = 0; 
            int count = 0;
            bool running = true;

            while (running)
            {
                Console.Write("Hej och välkommen till tärningssimulatorn!");

                Console.Write("\nHur många tärningar vill du kasta? ");
                running = int.TryParse(Console.ReadLine(), out int inputThrow);

                while (!running)
                {
                    if (!running)
                    {
                        //<statement för felhantering vid annat än siffra>
                        Console.WriteLine("Fel inmatning. Försök med siffror");
                        running = int.TryParse(Console.ReadLine(), out inputThrow);
                    }
                }

                Console.Write("Hur många sidor ska tärningen ha? ");
                running = int.TryParse(Console.ReadLine(), out int inputSide);

                while (!running)
                {
                    if (!running)
                    {
                        //<statement för felhantering vid annat än siffra>
                        Console.WriteLine("Fel inmatning. Försök med siffror");
                        running = int.TryParse(Console.ReadLine(), out inputSide);
                    }
                }

                Console.Write("Hur många gånger vill du kasta? ");
                running = int.TryParse(Console.ReadLine(), out int inputHits);

                while (!running)
                {
                    if (!running)
                    {
                        //<statement för felhantering vid annat än siffra>
                        Console.WriteLine("Fel inmatning. Försök med siffror");
                        running = int.TryParse(Console.ReadLine(), out inputHits);
                    }
                }

                for (int i = 1; i <= inputHits; i++) // loopar per omgång
                {
                    int makeZero = 0;
                    Console.WriteLine("Omgång " + i); //skrivs ut rätt

                    for (int j = 0; j < inputThrow; j++) 
                    {
                        int kast = rand.Next(1, inputSide + 1);
                        sum += kast; 
                        makeZero += kast; 
                        Console.Write(kast + " "); 
                    }
                    Console.WriteLine(" summa =  " + makeZero + "\n");
                }

                Console.WriteLine("Totala summan: " + sum); //Totala summan
                double divided = (double)sum / (double)inputHits;
                Console.WriteLine("Medelvärdet per omgång är: " + divided);

                Console.WriteLine("\nVill du spela igen?"); //fungerar bara med strängar

                while (count == 0)
                {
                    string yesOrNo = Console.ReadLine();

                    if (yesOrNo.ToLower() == "ja")
                    {
                        Console.Clear();
                        sum = 0;
                        divided = 0;
                        break;  //Break för att gå vidare vid ja
                    }

                    else if (yesOrNo.ToLower() == "nej")
                    {
                        running = false;
                        break; //Break för att avsluta vid false
                    }

                    else
                    {
                        Console.WriteLine("Fel val, försök igen med ja eller nej");
                    }
                }
            }
        }
    }
}
