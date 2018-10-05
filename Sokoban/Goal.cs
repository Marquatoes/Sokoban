using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Goal : ClearObject
    {
        public Goal(Square s) : base(s)
        {
            this.icon = 'x';
        }
    }
}