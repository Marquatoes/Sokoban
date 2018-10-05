using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    class Trap : ClearObject
    {
        int counter;
        public Trap(Square s) : base(s)
        {
            this.icon = '~';
            this.counter = 0;
        }
        public override void UsedBy(MovableObject m)
        {
            this.inUseBy = m;
            if (m is Crate || m is Truck)
            {
                counter++;
            }
            if (counter == 3)
            {
                this.icon = ' ';
            }
            if(m is Crate && counter > 3)
            {
                this.inUseBy = null;
            }
        }
    }
}
