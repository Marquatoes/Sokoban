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

            field.LoadLevel(5);
            field.ShowField();

            WaitForTurn();
        }

        public void WaitForTurn()
        {
            string key = Console.ReadKey().Key.ToString();
            player.Truck.Move();
            field.ShowField();
            WaitForTurn();
        }

        public bool AllCratesOnDestination()
        {
            throw new System.NotImplementedException();
        }
    }
}