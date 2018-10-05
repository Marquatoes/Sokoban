using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    class Trap : ClearObject
    {
        private int _counter;

        public Trap(Square s) : base(s)
        {
            this.icon = '~';
            this._counter = 0;
        }
        public override void UsedBy(MovableObject m)
        {
            this.InUseBy = m;
            if (m is Crate || m is Truck)
            {
                _counter++;
            }
            if (_counter == 3)
            {
                this.icon = ' ';
            }
            if(m is Crate && _counter > 3)
            {
                this.InUseBy = null;
            }
        }
    }
}
