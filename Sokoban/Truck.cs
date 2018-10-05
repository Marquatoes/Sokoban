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

        protected override bool CanMoveTo(Square n, string key)
        {
            var nextObj = n.SquareObject;
            if (nextObj.GetInUseBy() is Employee)
            {
                nextObj.GetInUseBy().Poke();
            }
            return base.CanMoveTo(n, key);
        }
    }
}