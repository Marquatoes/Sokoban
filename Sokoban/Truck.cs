using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Truck : FieldObject
    {
        public Square Loc { get; set; }

        public Truck()
        {
            this.icon = '@';
        }
        public void Move(string direction)
        {
            Loc = Loc.MoveObject(direction);
        }
    }
}