using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure.World
{
    public class Well : Rooms
    {
        public override void ToScreen()
        {
            Console.WriteLine(Description);

            if (!ListOfAnimals.Contains(GameSession.pig))
            {
                foreach (var item in ListOfItems)
                {
                    if (item == GameSession.bucket)
                    {
                        Console.WriteLine("Bredvid brunnen står det en [hink].");
                    }
                    else
                    {
                        if (item != GameSession.theWell)
                            Console.WriteLine(item.Name + ": " + item.Description);
                    }
                }
            }
            else if (ListOfAnimals.Contains(GameSession.pig))
            {
                GameSession.pig.ToScreen();
            }
        }

        public Well(GameData.Items theWell, Animals.Pig pig, Exits north)
        {
            this.Name = "Brunn";
            this.Description = "Du står vid kanten av ängen och framför dig finns en gammal [brunn] med vatten.\n" +
                "En stig leder tillbaka till ängen åt [norr]";
            this.ListOfItems.Add(theWell);
            this.ListOfAnimals.Add(pig);
            this.ListOfExists.Add(north);
        }
    }
}

