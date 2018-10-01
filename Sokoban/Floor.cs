using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    class Floor : ClearObject
    {
        public Floor(Square s) : base(s)
        {
            this.icon = '.';
        }

        public Floor(Square s, MovableObject m) : base(s, m)
        {
            this.icon = '.';
        }
    }
}
