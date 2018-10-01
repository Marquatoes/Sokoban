using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Truck : MovableObject
    {

        public Truck(Square s) : base(s)
        {
            this.Icon = '@';
        }
    }
}