using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Player
    {
        public Truck Truck { get; set; }

        public void MoveTruck(string direction)
        {
            Truck.Move(direction);
        }
    }
}