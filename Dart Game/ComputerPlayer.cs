using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DartSpeletTest4
{
    class ComputerPlayer
    {
        // Strängen playerName och listan playerTurns_list deklareras.
        private string computerName;
        private List<ComputerTurns> computerTurns_list = new List<ComputerTurns>();


        // Konstruktor för computerName
        public ComputerPlayer(string computerName = "")
        {
            _computerName = computerName;
        }

        // Get Set för computerName
        public string _computerName { get; set; }
        // Get Set för computerTurns_list
        public List<ComputerTurns> _computerTurns
        {
            get { return computerTurns_list; }
            set { computerTurns_list = value; }
        }

        // Metod för att lägga till en turn i listan.
        public void AddTurn(int arrow1, int arrow2, int arrow3)
        {
            computerTurns_list.Add(new ComputerTurns(arrow1, arrow2, arrow3));
        }

        // Den här metoden printar den totala poängen för rundan.
        public void PrintTotalScore()
        {
            foreach (var turns in computerTurns_list)
            {
                Console.WriteLine("Din score denna tur var: {0}", turns);
            }
        }

        // Den här metoden printar den totala poängen för hela spelet.
        public int TotalScore()
        {
            int total = 0;
            foreach (var turn in computerTurns_list)
            {
                total = total + turn.CurrentScore();
            }
            return total;
        }

        //Här används ToString för att få info om datorns namn.
        public override string ToString()
        {
            return string.Format(_computerName);
        }

    }

}
