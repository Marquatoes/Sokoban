using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    class Trap : ImmovableObject
    {
        private char icon;
        public Trap(Square s) : base(s)
        {
            this.icon = '~';
        }
    }
}
