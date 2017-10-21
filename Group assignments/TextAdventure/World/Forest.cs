using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure.World
{
    public class Forest : Rooms
    {
        public override void ToScreen()
        {
            Console.WriteLine(Description);

            if (!ListOfAnimals.Contains(GameSession.wolf))
            {
                foreach (var item in ListOfItems)
                {
                    if (item == GameSession.manure)
                    {
                        Console.WriteLine("Det ligger en hög med [gödsel]  på marken. Utmärkt som näring till växter vid plantering.");

                    }
                    else
                    {
                        Console.WriteLine(item.Name + ": " + item.Description);
                    }
                }
            }
            else if (ListOfAnimals.Contains(GameSession.wolf))
            {
                GameSession.wolf.ToScreen();

            }
        }

        public Forest(/*GameData.Items manure, */Animals.Wolf wolf, Exits north)
        {
            this.Name = "Skog";
            this.Description = "Du står i en skogsdunge med en mörk och tät skog omkring dig.\n" +
                "Åt [Söder] leder en väg tillbaka till ängen.";
            //this.ListOfItems.Add(manure);
            this.ListOfAnimals.Add(wolf);
            this.ListOfExists.Add(north);
        }
    }
}

