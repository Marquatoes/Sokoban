using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Goal : Obstacle
    {
        public Goal(Square s) :base(s)
        {
            base.Square = s;
        }
    }
}