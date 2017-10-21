using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TextAdventure.Animals
{
    public class Pig : Animals
    {
        public void ToScreen()
        {
            Console.WriteLine(Info);
        }

        public void SolveProblem()
        {
            Console.Clear();
            Console.WriteLine("Grisen äter svamparna och går sedan sin väg.");
            Thread.Sleep(2000);
        }

        public void Action()
        {
            Console.Clear();
            Console.WriteLine("Grisen rör sig mot dig och knuffar bort dig från området.");
            Thread.Sleep(2000);
        }

        public Pig()
        {
            this.Name = "Gris";
            this.Info = "En aggresiv [gris] står framför dig. " + "\n" +
                "Han verkar väldigt hungrig och har ingenting att äta." + "\n";
        }

    }
}

