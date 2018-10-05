using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Game
    {
        private Player player;
        private Field field;

        public void Start()
        {
            Console.Clear();
            Console.WriteLine("┌────────────────────────────────────────────────────┐");
            Console.WriteLine("| Welkom bij Sokoban                                 |");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("| betekenis van de symbolen    | doel van het spel   |");
            Console.WriteLine("|                              |                     |");
            Console.WriteLine("| spatie : outerspace          | duw met de truck    |");
            Console.WriteLine("|      # : muur                | de krat(ten)        |");
            Console.WriteLine("|      · : vloer               | naar de bestemming  |");
            Console.WriteLine("| O : krat                     |                     |");
            Console.WriteLine("| 0 : krat op bestemming       |                     |");
            Console.WriteLine("| x : bestemming               |                     |");
            Console.WriteLine("|      @ : truck               |                     |");
            Console.WriteLine("└────────────────────────────────────────────────────┘");

            Console.WriteLine(">   Kies een doolhof(1 - 6), s = stop");
            int level = 0;
            var key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    level = 1;
                    break;
                case ConsoleKey.D2:
                    level = 2;
                    break;
                case ConsoleKey.D3:
                    level = 3;
                    break;
                case ConsoleKey.D4:
                    level = 4;
                    break;
                case ConsoleKey.D5:
                    level = 5;
                    break;
                case ConsoleKey.D6:
                    level = 6;
                    break;
                case ConsoleKey.S:
                    Environment.Exit(0);
                    break;
            }
            if(level != 0)
            { 
                this.player = new Player();
                field = new Field(player);

                field.LoadLevel(level);
                field.ShowField();

                WaitForTurn();
            }
            else
            {
                Start();
            }

            
        }

        public void WaitForTurn()
        {
            string key = Console.ReadKey().Key.ToString();
            key = key.Split('A')[0];
            player.Truck.Move(key);
            field.ShowField();
            AllCratesOnDestination();
            WaitForTurn();
        }

        public void AllCratesOnDestination()
        {
            if(field.CratesOnDestination() == true)
            {
                Console.WriteLine("Hoera Opgelost! Druk op een toets om door te gaan");
                Console.ReadKey();
                Start();
            }
        }
    }
}