using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public abstract class SquareObject
    {
        public Square Square { get; set; }
        protected char icon;

        public SquareObject(Square s)
        {
            this.Square = s;
        }

        public char GetIcon()
        {
            return this.icon;
        }

        public virtual MovableObject InUseBy()
        {
            return null;
        }

        public virtual void UsedBy(MovableObject m)
        {

        }

        public virtual void SwapIcon()
        {

        }
    }
}