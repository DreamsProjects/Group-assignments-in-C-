using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TextAdventure
{
    public class Commands
    {
        public static string ExecuteCommand()
        {
            // Vilket värde som returneras till Switchen som styr rummen.
            string exitValue = "";

            // Styr loopen
            bool runCommand = true;

            // Printar användarens val
            GameData.Player.PlayerCommands();

            // Skriver ut miljön
            GameSession.currentRoom.ToScreen();
            Console.WriteLine();


            // Loop som håller användaren kvar i aktuella miljön
            while (runCommand)
            {
                // Läser in användarens input
                string command = Console.ReadLine().ToUpper();

                // Splittar upp inmatningen i array för att bättre kunna kontrolleras
                string[] commandArray = command.Split(' ');

                // Läser in vilket kommando användaren angett
                string action = commandArray[0];

                // Väljer vad som ska göras
                switch (action)
                {
                    case "GÅ":
                        if (commandArray.Length == 2)
                        {
                            // Kollar att vägen är möjlig att gå
                            if ((GameSession.currentRoom.ListOfExists.Exists(items => items.Name.ToUpper() == commandArray[1])))
                            {
                                foreach (var item in GameSession.currentRoom.ListOfExists)
                                {
                                    if (item.Name == commandArray[1])
                                    {
                                        // Hinner inte skrivas ut, men det finns en beskrivning vart man går
                                        Console.WriteLine(item.Description);
                                        exitValue = commandArray[1];
                                        runCommand = false;
                                    }

                                }
                            }

                            else
                            {
                                Console.WriteLine("\nDet är inte ett giltigt vädersträck");
                            }

                        }
                        else
                        {
                            Console.WriteLine("\nDu kan bara ange ett vädersträck");
                        }

                        break;

                    case "TA":
                        // Kollar längden på inmatningen
                        // Här kollas olika alternativ kring att ta upp items
                        if (commandArray.Length == 2)
                        {
                            if (GameSession.currentRoom == GameSession.garden && commandArray[1] == "PLANTERINGSYTA")
                            {
                                Console.WriteLine("\nDu kan inte plocka upp planteringsytan.");
                            }
                            else if (GameSession.currentRoom == GameSession.well && commandArray[1] == "BRUNN")
                            {
                                Console.WriteLine("\nDu kan inte plocka upp brunnen.");
                            }
                            else if (GameSession.currentRoom.ListOfItems.Exists(items => items.Name.ToUpper() == commandArray[1])) //Har problem med scope på currentLocation
                            {
                                int indexNr = GameSession.currentRoom.ListOfItems.FindIndex(items => items.Name.ToUpper() == commandArray[1]);

                                Console.WriteLine("Du tar upp " + GameSession.currentRoom.ListOfItems[indexNr].Name);
                                // Items.Inventory.inventoryList.Add(); lägga till item i player-inv.
                                //Room.listOfItems.Add(Det som togs upp); ta bort item i plats-inv.

                                GameData.Player.inventoryList.Add(GameSession.currentRoom.ListOfItems[indexNr]);

                                GameSession.currentRoom.ListOfItems.RemoveAt(indexNr);

                            }
                            else
                            {
                                Console.WriteLine("Det finns inget som heter så.");
                                //if item in room < 0;  skriv ut att det inte finns något att plocka upp
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nDu kan bara ta upp ett objekt.");
                        }
                        break;

                    case "SLÄPP":
                        if (commandArray.Length == 2)
                        {
                            // Kollar att man har det items man försöker släppa
                            if (GameData.Player.inventoryList.Exists(items => items.Name.ToUpper() == commandArray[1])) //Har problem med scope på currentLocation
                            {
                                int indexNr = GameData.Player.inventoryList.FindIndex(items => items.Name.ToUpper() == commandArray[1]);

                                Console.WriteLine("\nDu lägger ifrån dig " + GameData.Player.inventoryList[indexNr].Name);
                                // Items.Inventory.inventoryList.Add(); lägga till item i player-inv.
                                //Room.listOfItems.Add(Det som togs upp); ta bort item i plats-inv.

                                GameSession.currentRoom.ListOfItems.Add(GameData.Player.inventoryList[indexNr]);

                                GameData.Player.inventoryList.RemoveAt(indexNr);
                            }
                            else
                            {
                                Console.WriteLine("\nDet finns inget i inventory:n med det namnet");
                                //if item in room < 0;  skriv ut att det inte finns något att plocka upp
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nDu kan bara släppa ett objekt.");
                        }
                        break;

                    case "ANVÄND":
                        if (commandArray.Length > 3 && commandArray.Length == 4)
                        {
                            // Om rummet är Brunnen
                            if (GameSession.currentRoom == GameSession.well)
                            {
                                if ((GameData.Player.inventoryList.Exists(items => items.Name.ToUpper() == commandArray[1])) &&
                                                                   (GameSession.currentRoom.ListOfAnimals.Contains(GameSession.pig)) && (commandArray[3] == GameSession.pig.Name.ToUpper()) && (commandArray[1] == "SVAMP"))
                                {
                                    GameSession.well.ListOfAnimals.Remove(GameSession.pig);
                                    GameSession.pig.SolveProblem();
                                    GameData.Player.inventoryList.Remove(GameSession.mushrooms);
                                    GameSession.well.ListOfItems.Add(GameSession.bucket);
                                    runCommand = false;
                                    exitValue = "STANNA I RUM";
                                }
                                else if ((GameSession.well.ListOfAnimals.Contains(GameSession.pig)) && commandArray[1] != "SVAMP")
                                {
                                    GameSession.pig.Action();
                                    runCommand = false;
                                    exitValue = "NORR";
                                }
                                else if ((GameData.Player.inventoryList.Exists(items => items.Name.ToUpper() == commandArray[1])) &&
                                                              (commandArray[3] == "BRUNN") && (commandArray[1] == "HINK"))
                                {
                                    GameData.Player.inventoryList.Remove(GameSession.bucket);
                                    GameData.Player.inventoryList.Add(GameSession.waterbucket);


                                    Console.WriteLine("\nDu fyller hinken med vatten från brunnen.");


                                }
                                else
                                {
                                    Console.WriteLine("\nDet kan inte användas på detta sätt.");
                                }
                            }

                            // Om rummet är skogen
                            else if (GameSession.currentRoom == GameSession.forest)
                            {
                                if ((GameData.Player.inventoryList.Exists(items => items.Name.ToUpper() == commandArray[1])) &&
                                                                   (GameSession.currentRoom.ListOfAnimals.Contains(GameSession.wolf)) && (commandArray[3] == GameSession.wolf.Name.ToUpper()) && (commandArray[1] == "ELDFACKLA"))
                                {
                                    //GameSession.forest.listOfAnimals.Remove(GameSession.wolf);
                                    GameSession.wolf.SolveProblem();
                                    GameSession.forest.ListOfAnimals.Remove(GameSession.wolf);
                                    GameSession.forest.ListOfItems.Add(GameSession.manure);
                                    runCommand = false;
                                    exitValue = "STANNA I RUM";
                                }

                                if ((GameSession.currentRoom.ListOfAnimals.Contains(GameSession.wolf)) && /*(GameData.Player.inventoryList.Exists(items => items.Name.ToUpper() == commandArray[1])) &&
                                    (commandArray[3] == GameSession.wolf.Name.ToUpper()) && */(commandArray[1] != "ELDFACKLA"))
                                {
                                    GameSession.wolf.Action();

                                    runCommand = false;
                                }

                            }

                            // Om rummet är trädgården
                            else if (GameSession.currentRoom == GameSession.garden)
                            {
                                if ((GameData.Player.inventoryList.Exists(items => items.Name.ToUpper() == commandArray[1])) &&
                                    (commandArray[1] == "SPADE") && (commandArray[3] == "PLANTERINGSYTA"))
                                {
                                    Console.WriteLine("\nDu gräver en grop i planteringsytan. Här skulle något kunna planteras.");
                                    //GameSession.plantSequence = "[Grop]";
                                    GameSession.plantArea.Description = "En grop är grävd i planteringen. Här kan man så något.";

                                    Thread.Sleep(4000);
                                    runCommand = false;

                                    return "STANNA I RUM";

                                }
                                else if (((GameData.Player.inventoryList.Exists(items => items.Name.ToUpper() == commandArray[1])) &&
                                    (commandArray[1] == "FRÖN") && (commandArray[3] == "PLANTERINGSYTA")))
                                {
                                    GameData.Player.inventoryList.Remove(GameSession.magicBeans);

                                    Console.WriteLine("\nDu sår fröna i gropen. Men det kommer behövas näring innan något kan börja växa. ");
                                    GameSession.plantSequence = "[Grop] med frön";
                                    //GameData.Player.inventoryList.Remove(GameSession.magicBeans);
                                    GameSession.plantArea.Description = "Planteringen innehåller en grop fylld med frön. Nu skulle det behövas näring för att något ska växa.";

                                    Thread.Sleep(4000);
                                    runCommand = false;

                                    return "STANNA I RUM";

                                }
                                else if (((GameData.Player.inventoryList.Exists(items => items.Name.ToUpper() == commandArray[1])) &&
                                    (commandArray[1] == "GÖDSEL") && (commandArray[3] == "PLANTERINGSYTA")) && (GameSession.plantSequence.Contains("frön")))
                                {
                                    GameData.Player.inventoryList.Remove(GameSession.manure);

                                    Console.WriteLine("\nDu fyller gropen med gödsel, nu är det bara något kvar som saknas innan det är klar.");
                                    //GameData.Player.inventoryList.Remove(GameSession.manure);
                                    GameSession.plantSequence = "Gödselfylld [Grop]";
                                    GameSession.plantArea.Description = "Gropen i planteringen är fylld med gödsel, nu är det bara något som saknas.";
                                    Thread.Sleep(4000);

                                    runCommand = false;

                                    return "STANNA I RUM";


                                }
                                else if (((GameData.Player.inventoryList.Exists(items => items.Name.ToUpper() == commandArray[1])) &&
                                    (commandArray[1] == "VATTENHINK") && (commandArray[3] == "PLANTERINGSYTA")) && (GameSession.plantSequence.Contains("Gödselfylld")))
                                {
                                    GameData.Player.inventoryList.Remove(GameSession.waterbucket);
                                    GameData.Player.inventoryList.Add(GameSession.bucket);

                                    Console.Clear();
                                    Console.WriteLine("\nEfter att ha vattnat planteringen börjar ett träd att växa.\n" +
                                        "Du klättrar upp till toppen och tittar på utsikten.\n" +
                                        "\n============ DU HAR VUNNIT ==================\n");

                                    Thread.Sleep(10000);
                                    runCommand = false;
                                    GameSession.gameSessionIsRunning = false;
                                }
                                else
                                {
                                    Console.WriteLine("\nDet kan inte användas på detta sätt.");
                                }

                            }
                            else
                            {
                                Console.WriteLine("\nDet kan inte användas på detta sätt.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nDu måste använda ett objekt med/på ett annat.");
                        }
                        break;


                    case "KOMBINERA":
                        // Kollar kombinationsmöjligheterna
                        if (commandArray.Length == 4)
                        {
                            if ((GameData.Player.inventoryList.Exists(items => items.Name.ToUpper() == commandArray[1])) &&
                                GameData.Player.inventoryList.Exists(items => items.Name.ToUpper() == commandArray[3])) //Har problem med scope på currentLocation
                            {

                                if (commandArray.Contains("FACKLA") && commandArray.Contains("TÄNDSTICKOR"))
                                {
                                    GameData.Player.inventoryList.Remove(GameSession.matches);
                                    GameData.Player.inventoryList.Remove(GameSession.torch);

                                    GameData.Player.inventoryList.Add(GameSession.firetorch);
                                    Console.WriteLine("Du tänder facklan med tändstickorna, och skapar en ELDFACKLA");
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nIngen möjlig kobination.");
                                //if item in room < 0;  skriv ut att det inte finns något att plocka upp
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nDu måste kombinera NÅGOT med NÅGOT");
                        }
                        break;

                    case "INSPEKTERA":
                        // Ger en närmare beskrivning på angiven sak.
                        if (commandArray.Length == 2)
                        {
                            foreach (var item in GameData.Player.inventoryList)
                            {
                                if (item.Name.ToUpper() == commandArray[1])
                                {
                                    Console.WriteLine("\n" + item.Name + ": " + item.Description);
                                }

                            }
                            foreach (var item in GameSession.currentRoom.ListOfItems)
                            {
                                if (item.Name.ToUpper() == commandArray[1])
                                {
                                    Console.WriteLine("\n" + item.Name + ": " + item.Description);
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nDu kan bara Inspektera ett objekt åt gången.");
                        }

                        break;

                    case "UTFORSKA":
                        // Printar en miljöbeskrivning
                        if (commandArray.Length == 1)
                        {
                            Console.Clear();
                            GameSession.currentRoom.ToScreen();

                            if (GameSession.currentRoom.ListOfItems.Count > 0)
                            {
                                Console.WriteLine("\nHär finns:");
                                foreach (var item in GameSession.currentRoom.ListOfItems)
                                {
                                    Console.WriteLine(item.Name);
                                }
                            }
                            Console.WriteLine("\nMöjliga vägar vidare:");
                            foreach (var item in GameSession.currentRoom.ListOfExists)
                            {
                                Console.WriteLine(item.Name);
                            }
                        }
                        break;

                    case "VÄSKA":
                        // Printar ens inventory
                        Console.WriteLine("\nDINA SAKER I VÄSKAN:");
                        foreach (var item in GameData.Player.inventoryList)
                        {
                            Console.WriteLine(item.Name);
                        }
                        break;

                    default:
                        Console.WriteLine("\nFelaktig inmatning!");
                        break;
                }
            }

            return exitValue;
        }

    }
}


