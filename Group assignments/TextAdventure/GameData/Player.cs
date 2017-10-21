using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure.GameData
{
    public class Player
    {
        public static string playerName;

        public static List<GameData.Items> inventoryList = new List<GameData.Items>();

        public static void PlayerCommands()
        {
            Console.WriteLine("SPELARE: " + GameData.Player.playerName);
            Console.WriteLine("SPELVAL: [GÅ...] [ANVÄND...på...] [TA...] [SLÄPP...] [KOMBINERA...med...] [INSPEKTERA...] [UTFORSKA] [VÄSKA]");
            Console.WriteLine();
        }
    }
}
