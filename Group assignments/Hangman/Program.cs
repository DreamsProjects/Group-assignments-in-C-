using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            var tries = 0; //Antal spel
            bool win = false;
            string missChance = "";

            Console.WriteLine("Den som ska spela måste titta bort nu! ");
            Console.Write("Skriv in ett ord: ");
            var rightAnswer = Console.ReadLine().ToUpper(); 

            char[] rightAnswerInArray = rightAnswer.ToCharArray(); 
            char[] gameInfo = new char[rightAnswer.Length]; 

            for (int i = 0; i < gameInfo.Length; i++) //loop för att hantera gissningar
            {
                gameInfo[i] = '_';
            }

            Console.WriteLine("Enter för att fortsätta...");
            Console.ReadLine();
            Console.Clear(); 

            //Gissningarna
            while (tries < 6 && win == false)
            {
                string input;
                tries++;
                string testaGissnigar;

                for (int i = 0; i < gameInfo.Length; i++)
                {
                    Console.Write(gameInfo[i]);
                }
                Console.WriteLine("\nFörsök: {0}/6", tries);

                if (missChance.Length > 0) //Kommer upp när man börjar missar
                {
                    Console.WriteLine("Missar: {0}", missChance);
                }

                Console.WriteLine("\nGissa en bokstav eller hela ordet");
                input = Console.ReadLine().ToUpper();   //För att testa hela ordet


                if (input == rightAnswer)  //Testar om ordet är korrekt i sin helhet
                {
                    Console.WriteLine("Du har hittat ordet");
                    Console.WriteLine("Gissat ord är {0}", rightAnswer); //rätt svar på displayen
                    Console.WriteLine("Du gissade på {0} försök", tries); //Skriver ut antal försökta gissningar
                    Console.ReadLine();
                    win = true;
                }

                else if (input.Length == 1)  //Testar ny-bokstav
                {
                    var inputIChars = char.Parse(input); //För att testa bokstaven om gissaren har testat en bokstav.
                    bool alreadyGuessed = missChance.Contains(input);
                    bool rightGuess = false;
                    bool wrongGuess = false;

                    for (int i = 0; i < rightAnswerInArray.Length; i++)
                    {
                        if (inputIChars == gameInfo[i]) //Kontrollera om det är ny gissning
                        {
                            alreadyGuessed = true;
                        }

                        else if (rightAnswerInArray[i] == inputIChars) //kolla om det är rättgissning
                        {
                            gameInfo[i] = inputIChars;
                            rightGuess = true;
                        }

                        else if (rightAnswerInArray[i] != inputIChars) //Kolla om det är felgissning
                        {
                            wrongGuess = true;

                        }

                        testaGissnigar = new string(gameInfo); //För att testa om bokstäverna blivit det utvalda ord
                        if (testaGissnigar == rightAnswer)
                        {
                            win = true;
                        }
                    }
                    if (alreadyGuessed == false && rightGuess == false) //Kollar så att det är fel gissning
                    {
                        missChance += input;
                    }

                    if (alreadyGuessed == true)
                    {
                        tries--;
                        Console.WriteLine("Du har redan gissat denna bokstav");
                        Console.WriteLine("Enter för att fortsätta...");
                        Console.ReadLine();
                    }

                    else if (rightGuess == true)
                    {
                        Console.WriteLine("Bra gissat, {0} är rätt \n Enter för att fortsätta...", input);
                        tries--;
                        Console.ReadLine();
                    }

                    else if (wrongGuess == true)
                    {
                        Console.WriteLine("{0} är fel ", input);
                        Console.WriteLine("Enter för att fortsätta...");
                        Console.ReadLine();
                    }
                }

                else
                {
                    Console.WriteLine("FEL!!!\nDu har {0} försök kvar", 6 - tries);
                    Console.ReadLine();
                }
                Console.Clear();
            }

            if (tries < 6)
            {
                Console.WriteLine("GRATTIS!!! DU ÄR EN VINNARE\n Du klarade det på med {0} antal försök kvar", 6 - tries);
                Console.Write("\nDet rätta ordet som du skrev var " + rightAnswer);
            }
            else
            {
                Console.WriteLine("Du förlorade, det rätta ordet var: " + rightAnswer);
            }
        }
    }
}
