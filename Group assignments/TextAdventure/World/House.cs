using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure.World
{
    public class House : Rooms
    {
        public override void ToScreen()
        {
            Console.WriteLine(Description);

            foreach (var item in ListOfItems)
            {
                if (item == GameSession.magicBeans)
                {
                    Console.WriteLine("På bordet framför dig ligger det ett par [frön].");
                }
                else
                {
                    Console.WriteLine(item.Name + ": " + item.Description);
                }
            }
        }

        public House(GameData.Items magicBeans, Exits west, Exits east)
        {
            this.Name = "Hus";
            this.Description = "Du står i ett gammalt hus med knarrande golv, dammtäckta möbler och spindelnät i taket.\n" +
                "Det finns två utgångar ut huset, en åt [väst] och en åt [öst]";

            this.ListOfItems.Add(magicBeans);
            this.ListOfExists.Add(west);
            this.ListOfExists.Add(east);
        }
    }
}

