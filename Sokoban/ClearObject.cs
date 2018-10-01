using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public abstract class ClearObject : SquareObject
    {
        protected MovableObject inUseBy { get; set; }

        public ClearObject(Square s) : base(s)
        {

        }

        public ClearObject(Square s, MovableObject m) : base(s)
        {
            this.inUseBy = m;
        }

        public override MovableObject InUseBy()
        {
            return this.inUseBy;
        }

        public override void UsedBy(MovableObject m)
        {
            this.inUseBy = m;
        }
    }
}
