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
            Console.WriteLine("╔════════════════════════════════════════════════════╗");
            Console.WriteLine("║ Welkom bij Sokoban                                 ║");
            Console.WriteLine("║                                                    ║");
            Console.WriteLine("║ betekenis van de symbolen    ║ doel van het spel   ║");
            Console.WriteLine("║                              ║                     ║");
            Console.WriteLine("║   █ : muur                   ║ duw met de truck    ║");
            Console.WriteLine("║   · : vloer                  ║ de krat(ten)        ║");
            Console.WriteLine("║   O : krat                   ║ naar de bestemming  ║");
            Console.WriteLine("║   0 : krat op bestemming     ║                     ║");
            Console.WriteLine("║   x : bestemming             ║                     ║");
            Console.WriteLine("║   @ : truck                  ║                     ║");
            Console.WriteLine("║   ~ : valkuil                ║                     ║");
            Console.WriteLine("║   $ : medewerker             ║                     ║");
            Console.WriteLine("╚══════════════════════════════╩═════════════════════╝");

            Console.WriteLine(">   Kies een doolhof(1 - 6), s = stop");
            int level = -1;
            var key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.D0:
                    level = 0;
                    break;
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
            if(level != -1)
            {
                LoadLevel(level);
                WaitForTurn(level);
            }
            else
            {
                Start();
            }

            
        }

        public void LoadLevel(int level)
        {
            this.player = new Player();
            this.field = new Field(player);

            this.field.LoadLevel(level);
            this.field.ShowField();
        }

        public void WaitForTurn(int level)
        {
            string key = Console.ReadKey().Key.ToString();
            if (key == "UpArrow" || key == "DownArrow" || key == "RightArrow" || key == "LeftArrow")
            {
                key = key.Split('A')[0];
                player.Truck.Move(key);
                Employee _e;
                foreach (Employee e in field.GetEmployees())
                {
                    _e = e;
                    e.Action();
                }
                field.ShowField();
                AllCratesOnDestination();
            }
            else if(key == "R")
            {
                LoadLevel(level);
            }
            else if(key == "S")
            {
                Start();
            }
            WaitForTurn(level);
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