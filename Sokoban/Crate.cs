using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Crate : MovableObject
    {

        public Crate(Square s) : base(s)
        {
            this.icon = 'O';
        }

        public override void SwapIcon()
        {
            this.icon = this.icon == 'O' ? '0' : 'O';
        }
    }
}