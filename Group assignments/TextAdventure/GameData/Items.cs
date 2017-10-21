using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure.GameData
{
    public class Items
    {
        string name;
        string description;

        public string Name
        {
            get { return name; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public Items(string name, string description)
        {
            this.name = name;
            this.description = description;
        }
    }
}
