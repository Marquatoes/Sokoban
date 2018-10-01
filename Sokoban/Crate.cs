using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Crate : MovableObject
    {
        public bool Complete { get; internal set; }

        public Crate(Square s) : base(s)
        {
            this.icon = 'O';
            this.Complete = false;
        }
    }
}