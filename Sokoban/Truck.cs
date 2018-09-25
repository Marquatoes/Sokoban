using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Truck : Obstacle
    {
        public Truck(Square s) :base(s)
        {
            base.Square = s;
        }
        public void Move(char direction)
        {
            base.Square.MoveObject(direction);
        }
    }
}