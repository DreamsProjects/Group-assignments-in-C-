using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure.World
{
    public class Rooms
    {
        string name;
        string description;

        List<GameData.Items> listOfItems = new List<GameData.Items>();

        List<Animals.Animals> listOfAnimals = new List<Animals.Animals>();

        List<Exits> listOfExits = new List<Exits>();

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public List<GameData.Items> ListOfItems
        {
            get { return listOfItems; }
            set { listOfItems = value; }
        }

        public List<Animals.Animals> ListOfAnimals
        {
            get { return listOfAnimals; }
            set { listOfAnimals = value; }
        }

        public List<Exits> ListOfExists
        {
            get { return listOfExits; }
            set { listOfExits = value; }
        }

        public virtual void ToScreen()
        {

        }
    }
}

