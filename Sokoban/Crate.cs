using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Crate : Obstacle
    {

        public Crate(Square s) : base(s)
        {
            this.canMove = true;
            base.Square = s;
        }


        public void Move()
        {
            throw new System.NotImplementedException();
        }


    }
}