using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> lista2 = new List<char>();
            List<char> lista3 = new List<char>();
            bool looping = true;

            while (looping)
            {
                Console.Clear();
                Console.Write("Skriv din hemliga text: ");
                string secretText = Console.ReadLine().ToUpper();

                Console.WriteLine();

                Console.Write("Skriv i vilket tal som ska vara nyckeln (mellan 25 och -25): ");
                int key = int.Parse(Console.ReadLine());

                Console.WriteLine();

                if (key >= (-25) && key <= 25)
                {
                    List<int> list = new List<int>();
                    int counter = 0;
                    byte[] ascii = Encoding.ASCII.GetBytes(secretText); //gör om bokstäverna i hemligatexten till byte och sätter dem i en array...
                    foreach (Byte letter in ascii) // Loopar igenom listan
                    {
                        if (letter >= 65 || letter >= 90)//Checkar ifall ascii är mellan A-Z...
                        {
                            int crypted = letter;
                            crypted -= key;

                            if (crypted - 65 < 0) //65 i acii är A
                            {
                                crypted -= 65;
                                crypted = 91 + crypted;
                            }

                            else if (crypted - 90 > 0) //90 i aci är Z
                            {
                                crypted -= 90;
                                crypted = 64 + crypted;
                            }

                            list.Add(crypted);
                            counter++;
                        }

                        else
                        {
                            int a = letter;
                            list.Remove(a);//Tar bort alla bokstäver som inte är A-Z samt alla tecken
                        }
                    }

                    Console.Write("Den krypterade koden är: ");
                    List<string> cryptedList = new List<string>();

                    for (int i = 0; i < counter; i++)
                    {
                        //<statement för att skriva ut den krypterade koden>
                        int cryptCode = list[i];
                        char character = (char)cryptCode;
                        cryptedList.Add(character.ToString());
                        Console.Write(cryptedList[i]);
                    }

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.Write("Skriv in din krypterade kod: ");
                    string cryptToRegular = Console.ReadLine().ToUpper();
                    Console.WriteLine();

                    Console.Write("Lås upp krypteringen med din nyckel: ");
                    int key2 = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                    if (key2 >= (-26) && key <= 26) //Dekrypteringskoden
                    {
                        byte[] ascii2 = Encoding.ASCII.GetBytes(cryptToRegular);
                        foreach (Byte b in ascii2)
                        {
                            if (b >= 65 || b >= 90)//Checkar ifall ascii är mellan A-Z
                            {
                                int aciiCrypt = b;         //gör om char till ascii
                                aciiCrypt += key2;       

                                if (aciiCrypt - 65 < 0)
                                {
                                    aciiCrypt -= 65;
                                    aciiCrypt = 91 + aciiCrypt;
                                }
                                else if (aciiCrypt - 90 > 0)
                                {
                                    aciiCrypt -= 90;
                                    aciiCrypt = 64 + aciiCrypt;
                                }
                                lista2.Add((char)aciiCrypt);
                            }
                        }

                        for (int i = 0; i < counter; i++)
                        {
                            int result = lista2[i];
                            char character = (char)result;
                            lista3.Add(character);
                            Console.Write(lista3[i]);
                        }
                        Console.ReadLine();
                        looping = false;
                    }
                }

                else
                {
                    Console.WriteLine("Felaktig inmatning! Tryck enter för att göra ett nytt försök!");
                    Console.ReadLine();
                }
            }

        }
    }
}
