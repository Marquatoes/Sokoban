using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    
    public class Vak
    {
        private Vloer vloer;
        protected int row;
        protected int column;

        public Vak(Vloer vloer, int row , int column)
        {
            this.vloer = vloer;
            this.row = row;
            this.column = column;
        }

        public void IsMovable()
        {
            throw new System.NotImplementedException();
        }
    }
}