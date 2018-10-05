using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public abstract class MovableObject : SquareObject
    {

        protected MovableObject(Square s) : base(s) { }

        public virtual void Move(string key)
        {
            var nextSq = (Square)this.Square.GetType().GetProperty(key).GetValue(this.Square);
            if(CanMoveTo(nextSq, key))
            {
                if(nextSq.SquareObject.GetInUseBy() is Crate || nextSq.SquareObject.GetInUseBy() is Truck)
                {
                    var movable = nextSq.SquareObject.GetInUseBy();
                    movable.Move(key);
                }

                this.Square.SquareObject.UsedBy(null);
                this.Square = nextSq;
                this.Square.SquareObject.UsedBy(this);
            }
        }

        protected virtual bool CanMoveTo(Square n, string key)
        {
            var nextObj = n.SquareObject;
            if (nextObj is ClearObject)
            {
                var nextOfNext = n.GetType().GetProperty(key).GetValue(n) as Square;
                if(nextObj.GetInUseBy() != null && !nextObj.GetInUseBy().CanMoveTo(nextOfNext, key))
                {
                    return false;
                }
                else if(nextObj.GetInUseBy() is Employee)
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
