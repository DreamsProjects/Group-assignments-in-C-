using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure.World
{
    public class Garden : Rooms
    {
        public override void ToScreen()
        {
            Console.WriteLine(Description);
            //Console.WriteLine("Mitt i trädgården finns en " + GameSession.plantArea.Name);
            //Console.WriteLine("Mitt i trädgården finns en " + GameSession.plantSequence);
            Console.WriteLine("Mitt i trädgården finns en [planteringsyta]. " + GameSession.plantArea.Description);
            foreach (var item in ListOfItems)
            {
                if (item == GameSession.shovel)
                {
                    Console.WriteLine("På marken ligger det en [spade].");
                }
                else
                {
                    if (item != GameSession.plantArea)
                        Console.WriteLine(item.Name);
                }
            }
        }

        public Garden(GameData.Items plantArea, GameData.Items shovel, /*GameData.Items manure, */Exits east)
        {
            this.Name = "Trädgård";
            this.Description = "Du står i en vissen trädgård som behöver lite nytt liv. Det skulle behövas planteras något här.\n" +
                "åt [Öst] leder en grusgång till huset.";
            this.ListOfItems.Add(shovel);
            this.ListOfItems.Add(plantArea);
            this.ListOfExists.Add(east);
        }
    }
}
