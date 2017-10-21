using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    class GameSession
    {
        // Spelinnehållet skapas
        public static World.Exits exitNorth = new World.Exits("NORR", "Du går norrut.");
        public static World.Exits exitSouth = new World.Exits("SÖDER", "Du går söderut.");
        public static World.Exits exitWest = new World.Exits("VÄST", "Du går västerut.");
        public static World.Exits exitEast = new World.Exits("ÖST", "Du går österut.");

        public static GameData.Items manure = new GameData.Items("Gödsel", "Bra näring vid plantering.");
        public static GameData.Items shovel = new GameData.Items("Spade", "Bra att gräva med.");
        public static GameData.Items magicBeans = new GameData.Items("Frön", "Plantera för få en magisk växt.");
        public static GameData.Items mushrooms = new GameData.Items("Svamp", "Ätbart för många djur.");
        public static GameData.Items bucket = new GameData.Items("Hink", "Kan fyllas med innehåll.");
        public static GameData.Items torch = new GameData.Items("Fackla", "Kan tändas.");
        public static GameData.Items matches = new GameData.Items("Tändstickor", "Använd för att göra eld.");
        public static GameData.Items firetorch = new GameData.Items("Eldfackla", "En brinnande fackla.");
        public static GameData.Items waterbucket = new GameData.Items("Vattenhink", "Hink fylld med vatten.");
        public static GameData.Items plantArea = new GameData.Items("Planteringsyta", "Här skulle man kunna odla något. Men först måste man gräva en grop.");
        public static GameData.Items theWell = new GameData.Items("Brunn", "Här kan man hämta vatten, om man har något att bära det i. ");

        public static Animals.Pig pig = new Animals.Pig();
        public static Animals.Wolf wolf = new Animals.Wolf();

        public static World.Well well = new World.Well(theWell,pig, exitNorth);
        public static World.House house = new World.House(magicBeans, exitWest, exitEast);
        public static World.Garden garden = new World.Garden(plantArea, shovel, exitEast);
        public static World.Forest forest = new World.Forest(/*manure, */wolf, exitSouth);
        public static World.MushroomMeadow meadow = new World.MushroomMeadow(mushrooms, exitNorth, exitSouth, exitWest);

        public static string plantSequence = "[Planteringsyta]";

        public static World.Rooms currentRoom = new World.Rooms();

        public static bool gameSessionIsRunning = true;

        public void PlayGame()
        {
            Console.Write("Ange namn på spelaren: ");
            GameData.Player.playerName = Console.ReadLine();

            GameData.Player.inventoryList.Add(torch);
            GameData.Player.inventoryList.Add(matches);

            currentRoom = house;
            string goNext = "";
            while (gameSessionIsRunning)
            {
                Console.Clear();

                // Här väljs vilken miljö man befinner sig i.
                switch (currentRoom.Name)
                {
                    case "Hus":

                        goNext = Commands.ExecuteCommand();
                        if (goNext == "ÖST")
                        {
                            currentRoom = meadow;
                        }
                        else if (goNext == "VÄST")
                        {
                            currentRoom = garden;
                        }

                        break;
                    case "Trädgård":

                        goNext = Commands.ExecuteCommand();
                        if (goNext == "ÖST")
                        {
                            currentRoom = house;
                        }
                        else if (goNext == "STANNA I RUM")
                        {
                            currentRoom = garden;
                            // CurrentRoom är detsamma, laddar om rum
                        }

                        break;
                    case "Äng":

                        goNext = Commands.ExecuteCommand();
                        if (goNext == "VÄST")
                        {
                            currentRoom = house;
                        }
                        else if (goNext == "NORR")
                        {
                            currentRoom = forest;
                        }
                        else if (goNext == "SÖDER")
                        {
                            currentRoom = well;
                        }

                        break;
                    case "Brunn":

                        goNext = Commands.ExecuteCommand();
                        if (goNext == "NORR")
                        {
                            currentRoom = meadow;
                        }
                        else if (goNext == "STANNA I RUM")
                        {
                            currentRoom = well;
                            // CurrentRoom är detsamma, laddar om rum
                        }

                        break;
                    case "Skog":

                        goNext = Commands.ExecuteCommand();
                        if (goNext == "SÖDER")
                        {
                            currentRoom = meadow;
                        }
                        else if (goNext == "STANNA I RUM")
                        {
                            currentRoom = forest;
                            // CurrentRoom är detsamma, laddar om rum
                        }
                        break;

                    default:
                        break;
                }
            }
        }

        public GameSession()
        {
            PlayGame();
        }

    }
}

