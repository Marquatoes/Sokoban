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
            this.icon = '@';
        }

        public override bool canMoveTo(Square n, string key)
        {
            var nextObj = n.SquareObject;
            if (nextObj.InUseBy() is Employee)
            {
                nextObj.InUseBy().Poke();
            }
            return base.canMoveTo(n, key);
        }
    }
}