using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Crate : FieldObject
    {
        public bool Complete { get; internal set; }

        public Crate()
        {
            this.icon = 'O';
            this.canMove = true;
            this.Complete = false;
        }
    }
}