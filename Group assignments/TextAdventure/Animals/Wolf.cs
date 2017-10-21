using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TextAdventure.Animals
{
    public class Wolf : Animals
    {
        public void ToScreen()
        {
            Console.WriteLine(Info);
        }

        public void SolveProblem()
        {
            Console.Clear();
            Console.WriteLine("Du skrämmer vargen med din fackla och han springer iväg, och syns aldrig till igen");
            Thread.Sleep(2000);

        }

        public void Action()
        {
            Console.Clear();
            Console.WriteLine("Vargen attackerar och äter dig levande!\n\n" +
                "========= GAME OVER ========");
            Thread.Sleep(4000);
            GameSession.gameSessionIsRunning = false;
        }

        public Wolf()
        {
            this.Name = "Varg";
            this.Info = "Du hör ett fruktansvärt morrande och vänder dig om, och får se en [varg] börja närma sig.";
        }
    }
}

