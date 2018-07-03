using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dartspelet
{

    class Program
    {
        static void Main(string[] args)
        {
            // Här skapas en instans av klassen Game och spelat körs igång via GameStart-metoden.
            Game MainGame = new Game();

            MainGame.GameStart();


        }
    }
}
