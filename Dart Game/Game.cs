using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dartspelet
{
    class Game
    {
        /* I klassen game behövs totalPlayers som sedan används i en metod för att skriva in hur många spelare man vill ha.
         * totalComputers används för att lägga till det antalet datorer som man vill ha.
         * En ny Random deklareras som kommer att användas sedan.
         * En lista deklareras också som kommer att innehålla spelarna från Player-klassen.
         * En till lista deklareras som innehåller eventuella datorer.
         * randomScore används för att ge datorn slumpmässiga poäng.
        */
        private int totalPlayers;
        private int totalComputers;
        Random randomPercent = new Random();
        Random randomScore = new Random();
        private List<Player> PlayersList = new List<Player>();
        private List<DartSpeletTest4.ComputerPlayer> ComputersList = new List<DartSpeletTest4.ComputerPlayer>();


        // Dessa arrows används för att skicka information till metoden playerThrow.
        private int arrow1;
        private int arrow2;
        private int arrow3;
        // De här olika integrarna kommer sedan att få ett slumpmässigt nummer mellan 1-100 tilldelade.
        private int percent1;
        private int percent2;
        private int percent3;

        // Inne i den här metoden sker själva "spelet" via olika loopar.
        public void GameStart()
        {
            // Här startas metoden AddPlayer, och totalScore som kommer ha reda på den totala poängen deklareras.
            AddPlayer();
            // AddComputer fungerar liknande som för AddPlayer.
            AddComputer();
            // TotalScore och totalScoreComputer används för att avsluta loopen när önskat poäng nåtts.
            int totalScore = 0;
            int totalScoreComputer = 0;
            // scoreGoal är poängen man får skriva in vad man vill köra till, symboliskt satt till 301 här.
            int scoreGoal = 301;

            // Här får man bestämma vilken poäng man vill köra till. 
            Console.WriteLine("What score would you like to play for?");
            scoreGoal = Convert.ToInt32(Console.ReadLine());

            // I den här metoden sker det mesta av spelet. 
            do
            {
                /* Loopas varje spelare igenom och man gör sina kast.
                 * Det börjar med att man får tre stycken olika slumptal genererade.
                 * Spelaren välkomnas och får kasta 3 stycken pilar. 
                 * Dessa "kast" går till playerThrow med information från percent1, percent2, percent3. 
                 * Procenttalen skulle man egentligen kunna lägga i metoden.
                 * Sedan skrivs talen arrow1, arrow2 och arrow3 ut så spelaren ser sina poäng.
                 * Sist så lagras talen via metoden AddTurn i klassen Player.
                 * Variabeln totalScore håller reda på den totala poängen.
                 */
                foreach (var Player in PlayersList)
                {
                    percent1 = randomPercent.Next(0, 100);
                    percent2 = randomPercent.Next(0, 100);
                    percent3 = randomPercent.Next(0, 100);
                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine("It is {0} turn to play! You get three arrows.", Player);
                    arrow1 = PlayerThrow(percent1);
                    arrow2 = PlayerThrow(percent2);
                    arrow3 = PlayerThrow(percent3);

                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine("Your points are: First arrow: {0} points. Second arrow: {1} points. Third arrow: {2} points.", arrow1, arrow2, arrow3);
                    Console.WriteLine("{0}s points this round are: {1}", Player, (arrow1 + arrow2 + arrow3));

                    Player.AddTurn(arrow1, arrow2, arrow3);
                    totalScore = Player.TotalScore();

                }
                /* Om det finns fler datorer än 0 så skapas deras runda här. 
                 * Jag har satt random-poängen mellan 0-15 för att det ska vara någorlunda lätt att spela mot datorn.
                 * Resten av if-satsen fungerar som ovanstående foreach.
                */
                if (totalComputers > 0)
                {
                    foreach (var Computer in ComputersList)
                    {
                        arrow1 = randomScore.Next(0, 15);
                        arrow2 = randomScore.Next(0, 15);
                        arrow3 = randomScore.Next(0, 15);
                        Console.WriteLine("The computer scored: First arrow: {0} points. Second arrow: {1} points. Third arrow: {2} points.", arrow1, arrow2, arrow3);
                        Computer.AddTurn(arrow1, arrow2, arrow3);
                        totalScoreComputer = Computer.TotalScore();
                    }
                }

                // Här printas poängen ut för varje spelare.
                foreach (var turn in PlayersList)
                {
                    Console.WriteLine("The total score for {0} so far is {1}", turn, turn.TotalScore());

                    Console.WriteLine("-----------------------------------------");
                }
                // Här printas poängen ut för varje dator.
                if (totalComputers > 0)
                {
                    foreach (var computer in ComputersList)
                    {
                        Console.WriteLine("The total score for {0} so far is {1}", computer, computer.TotalScore());

                        Console.WriteLine("-----------------------------------------");
                    }
                }
                // Den totala poängen kan man sätta själva via scoreGoal-variabeln. 
            } while ((totalScore <= scoreGoal) && (totalScoreComputer <= scoreGoal));

            foreach (var Player in PlayersList)
            {
                Console.WriteLine("The total score for {0} is: {1}", Player, Player.TotalScore());
                Player.PrintTotalScore();
            }

            Console.WriteLine("Thanks for playing! Press any key to exit.");
            Console.ReadKey();
        }

        // Den här metoden sköter själva kastet.
        public int PlayerThrow(int percent)
        {
            /* Spelaren välkomnas och får en switch-case meny. Man får välja tre areor att kasta mot.
             * Varje område som man kan kasta mot har en svårighetsgrad, mitten är svårast sen blir det lättare ju längre ut det går.
             * Efter valet av område så testas inparametern percent mot den satta svårighetsgraden. 
             * Ett kast med mitten prövas mot talet 85. Om variabeln percent är större än 85 så får man en träff.
             * Är percent mindre än 85 så får man en miss och poängen 0.
            */
            Console.WriteLine("The middle gives the most points, but is the most difficult part to hit. It gets easier the further outwards you throw.");
            Console.WriteLine("Press [1] to aim for the middle \nPress [2] to aim for the slightly outer layers \nPress [3] to aim for the most outwards part");
            int switchSelection = Convert.ToInt32(Console.ReadLine());
            // Nedanstående slumptal kommer att användas sedan för att slumpa fram poäng efter man fått en "träff".
            Random randomScore = new Random();
            // Poängen deklareras och kommer sedan att returneras efter switch-case nedan.
            int score = 0;

            // Den här switchcase innehåller flertalet cases beroende på vad man väljer. 
            switch (switchSelection)
            {
                case 1:

                    if (percent > 85)
                    {
                        score = 20;
                        Console.WriteLine("Bullseye! You got {0} points!", score);
                    }
                    else
                    {
                        score = 0;
                        Console.WriteLine("Miss!");
                    }
                    break;
                case 2:

                    if (percent > 60)
                    {
                        score = randomScore.Next(5, 15);
                        Console.WriteLine("Nice hit! You got {0} points!", score);
                    }
                    else
                    {
                        score = 0;
                        Console.WriteLine("Miss!");
                    }
                    break;
                case 3:
                    if (percent > 30)
                    {
                        score = randomScore.Next(1, 10);
                        Console.WriteLine("Hit! You got {0} points!", score);
                    }
                    else
                    {
                        score = 0;
                        Console.WriteLine("Miss!");
                    }
                    break;
                default:
                    Console.WriteLine("Var god välj en siffra mellan 1-3");
                    break;
            }
            return score;
        }

        // Här lägger vi till spelare. 
        public void AddPlayer()
        {
            // Man får välja antal spelare via varabeln totalPlayers.
            Console.WriteLine("How many players are there?");
            totalPlayers = Convert.ToInt32(Console.ReadLine());

            // I den här for-loopen skrivs alla spelare in och blir varsitt objekt i en lista.
            for (int i = 0; i < totalPlayers; i++)
            {
                Console.WriteLine("Please write your name and press enter.");
                PlayersList.Add(new Player()
                {
                    _playerName = Console.ReadLine(),

                });
                Console.WriteLine("------------------------------------------");

            }

        }

        /* Den här metoden fungerar som AddPlayer, fast man lägger till en dator. 
         * Från början tänkte jag att dessa datornamn skulle slumpas fram, men det var en sen idé som jag inte hann med.
        */
        public void AddComputer()
        {
            Console.WriteLine("Would you like to add computers? Write down how many computers you would like to add and press enter.");
            totalComputers = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < totalComputers; i++)
            {
                Console.WriteLine("Please write the computer's name and press enter.");
                ComputersList.Add(new DartSpeletTest4.ComputerPlayer()
                {
                    _computerName = Console.ReadLine(),

                });
                Console.WriteLine("------------------------------------------");
            }
        }

        // Kallar To-String som skriver ut vilka spelare det är.
        public void CountPlayers()
        {
            foreach (Player player in PlayersList)
            {
                Console.WriteLine("This is method CountPlayers and the player is {0}", player);

            }
        }


    }
}
