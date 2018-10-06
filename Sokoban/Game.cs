using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Game
    {
        private Player _player;
        private Field _field;

        public void Lobby()
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
                Lobby();
            }
        }

        private void LoadLevel(int level)
        {
            this._player = new Player();
            this._field = new Field(_player, level);
        }

        private void WaitForTurn(int level)
        {
            string key = Console.ReadKey().Key.ToString();
            if (key == "UpArrow" || key == "DownArrow" || key == "RightArrow" || key == "LeftArrow")
            {
                key = key.Split('A')[0];
                _player.MoveTruck(key);
                foreach (Employee e in _field.GetEmployees())
                {
                    e.Action();
                }
                _field.ShowField();
                AllCratesOnDestination();
            }
            else if(key == "R")
            {
                LoadLevel(level);
            }
            else if(key == "S")
            {
                Lobby();
            }
            WaitForTurn(level);
        }

        private void AllCratesOnDestination()
        {
            if(_field.CratesOnDestination() == true)
            {
                Console.WriteLine("Hoera Opgelost! Druk op een toets om door te gaan");
                Console.ReadKey();
                Lobby();
            }
        }
    }
}