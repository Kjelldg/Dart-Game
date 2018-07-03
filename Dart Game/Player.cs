using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dartspelet
{
    class Player
    {
        // Strängen playerName och listan playerTurns_list deklareras.
        private string playerName;
        private List<Turns> playerTurns_list = new List<Turns>();


        // Konstruktor för playerName
        public Player(string playerName = "")
        {
            _playerName = playerName;
        }

        // Get Set för playerName
        public string _playerName { get; set; }
        // Get Set för playerTurns_list
        public List<Turns> _playerTurns
        {
            get { return playerTurns_list; }
            set { playerTurns_list = value; }
        }

        // Metod för att lägga till en turn i listan.
        public void AddTurn(int arrow1, int arrow2, int arrow3)
        {
            playerTurns_list.Add(new Turns(arrow1, arrow2, arrow3));
        }

        // Den här metoden printar den total poängen för rundan.
        public void PrintTotalScore()
        {
            foreach (var turns in playerTurns_list)
            {
                Console.WriteLine("Din score denna tur var: {0}", turns);
            }
        }

        // Den här metoden printar den totala poängen för hela spelet.
        public int TotalScore()
        {
            int total = 0;
            foreach (var turn in playerTurns_list)
            {
                total = total + turn.CurrentScore();
            }
            return total;
        }

        //Här används ToString för att få info om spelarens namn.
        public override string ToString()
        {
            return string.Format(_playerName);
        }

    }
}
