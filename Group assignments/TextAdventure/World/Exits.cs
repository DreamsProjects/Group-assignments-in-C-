using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure.World
{
    public class Exits
    {
        private string name;
        private string description;

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

        public Exits(string name, string description)
        {
            this.name = name;
            this.description = description;
        }
    }
}
