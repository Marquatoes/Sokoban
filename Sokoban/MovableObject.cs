using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public abstract class MovableObject : SquareObject
    {

        public MovableObject(Square s) : base(s) { }

        public virtual void Move(string key)
        {
            var nextSq = (Square)this.Square.GetType().GetProperty(key).GetValue(this.Square);
            if(canMoveTo(nextSq, key))
            {
                if(nextSq.SquareObject.InUseBy() is Crate || nextSq.SquareObject.InUseBy() is Truck)
                {
                    var movable = nextSq.SquareObject.InUseBy();
                    movable.Move(key);
                }

                if (this is Crate && this.Square.SquareObject is Goal)
                {
                    this.SwapIcon();
                }

                this.Square.SquareObject.UsedBy(null);
                this.Square = nextSq;
                this.Square.SquareObject.UsedBy(this);
                if(this is Crate && this.Square.SquareObject is Goal)
                {
                    this.SwapIcon();
                }
            }
        }

        public virtual bool canMoveTo(Square n, string key)
        {
            var nextObj = n.SquareObject;
            if (nextObj is ClearObject)
            {
                var nextOfNext = n.GetType().GetProperty(key).GetValue(n) as Square;
                if(nextObj.InUseBy() != null && !nextObj.InUseBy().canMoveTo(nextOfNext, key))
                {
                    return false;
                }
                else if(nextObj.InUseBy() is Employee)
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        public virtual void Poke() { }
    }
}
