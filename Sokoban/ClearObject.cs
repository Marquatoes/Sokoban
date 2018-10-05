using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public abstract class ClearObject : SquareObject
    {
        protected MovableObject InUseBy { get; set; }

        public ClearObject(Square s) : base(s) { }

        public ClearObject(Square s, MovableObject m) : base(s)
        {
            this.InUseBy = m;
        }

        public override MovableObject GetInUseBy()
        {
            return this.InUseBy;
        }

        public override void UsedBy(MovableObject m)
        {
            this.InUseBy = m;
        }
    }
}
