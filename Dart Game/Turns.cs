using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dartspelet
{
    class Turns
    {

        // Här finns de integrar som kommer att användas som pilar sedan, satta till private.
        private int arrow1;
        private int arrow2;
        private int arrow3;

        // Den här listan ska hålla reda på varje spelares poäng.
        private List<Turns> totalScore_list = new List<Turns>();


        // Konstruktor för turns.
        public Turns(int arrow1 = 0, int arrow2 = 0, int arrow3 = 0)
        {
            _arrow1 = arrow1;
            _arrow2 = arrow2;
            _arrow3 = arrow3;
        }

        // Get set för alla int
        public int _arrow1 { get; set; }
        public int _arrow2 { get; set; }
        public int _arrow3 { get; set; }

        // Den här metoden räknar ihop spelarens poäng för alla pilar och returnerar dem.
        public int CurrentScore()
        {
            int totalScore;
            totalScore = _arrow1 + _arrow2 + _arrow3;
            return totalScore;
        }

        // Get Set för totalScore_list-listan.
        public List<Turns> _totalScore_list
        {
            get { return totalScore_list; }
            set { totalScore_list = value; }
        }

        // Här används ToString för att skicka vilka pilar som gav vilka poäng.
        public override string ToString()
        {
            return string.Format("Arrow 1: {0} points, Arrow 2: {1} points and Arrow 3: {2} points", _arrow1, _arrow2, _arrow3);
        }

    }
}
