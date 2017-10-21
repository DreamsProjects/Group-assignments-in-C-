using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure.World
{
    public class MushroomMeadow : Rooms
    {
        public override void ToScreen()
        {
            Console.WriteLine(Description);

            foreach (var item in ListOfItems)
            {
                if (item == GameSession.mushrooms)
                {
                    Console.WriteLine("På marken växer det en stor fin [svamp].");
                }
                else
                {

                    Console.WriteLine(item.Name + ": " + item.Description);
                }
            }
        }

        public MushroomMeadow(GameData.Items mushrooms, Exits north, Exits south, Exits west)
        {
            this.Name = "Äng";
            this.Description = "Du står på en liten äng utanför huset.\n" +
                "Det går en väg åt [norr] som leder till en mörk skog, en väg åt [söder] som leder till en gammal brunn\n" +
                "och en grusgång åt [väst] som leder till huset.";
            this.ListOfItems.Add(mushrooms);
            this.ListOfExists.Add(north);
            this.ListOfExists.Add(south);
            this.ListOfExists.Add(west);
        }
    }
}

