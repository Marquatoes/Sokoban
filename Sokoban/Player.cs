using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Player
    {
        public Square locatie { get; set; }

        public Truck Truck
        {
            get => default(Truck);
            set
            {
            }
        }

        public void MoveTruck(Square oldlocation, string direction)
        {
            throw new System.NotImplementedException();
        }
    }
}