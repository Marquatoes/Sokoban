using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Game
    {

        public Player Speler
        {
            get => default(Player);
            set
            {
            }
        }

        public Field Vloer
        {
            get;
            set;
        }

        public bool AllCratesOnDestination()
        {
            throw new System.NotImplementedException();
        }
    }
}