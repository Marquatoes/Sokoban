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
            this.player = new Player();
            field = new Field(player);

            field.LoadLevel(0);
            field.ShowField();

            WaitForTurn();
        }

        public void WaitForTurn()
        {
            string key = Console.ReadKey().Key.ToString();
            key = key.Split('A')[0];
            player.Truck.Move(key);
            field.ShowField();
            WaitForTurn();
        }

        public bool AllCratesOnDestination()
        {
            throw new System.NotImplementedException();
        }
    }
}