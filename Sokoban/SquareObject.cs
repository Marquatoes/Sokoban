using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public abstract class SquareObject
    {
        public Square Square { get; set; }
        public char Icon { get; set; }

        public SquareObject(Square s)
        {
            this.Square = s;
        }
    }
}