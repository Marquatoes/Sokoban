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

        protected SquareObject(Square s)
        {
            this.Square = s;
        }

        public char GetIcon()
        {
            return this.icon;
        }

        public virtual MovableObject GetInUseBy()
        {
            return null;
        }

        public virtual void UsedBy(MovableObject m) { }

        protected virtual void SwapIcon() { }
    }
}