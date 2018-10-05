using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Crate : MovableObject
    {
        public Crate(Square s) : base(s)
        {
            this.icon = 'O';
        }

        protected override void SwapIcon() => this.icon = this.icon == 'O' ? '0' : 'O';

        public override void Move(string key)
        {
            var nextSq = (Square)this.Square.GetType().GetProperty(key).GetValue(this.Square);
            if (CanMoveTo(nextSq, key))
            {
                if (this.Square.SquareObject is Goal)
                    this.SwapIcon();

                this.Square.SquareObject.UsedBy(null);
                this.Square = nextSq;
                this.Square.SquareObject.UsedBy(this);

                if (this.Square.SquareObject is Goal)
                    this.SwapIcon();
            }
        }

        protected override bool CanMoveTo(Square n, string key)
        {
            var nextObj = n.SquareObject;
            if (nextObj.GetInUseBy() is Crate)
            {
                return false;
            }
            return base.CanMoveTo(n, key);
        }
    }
}