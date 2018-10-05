using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{

    public class Square
    {
        public Square Left { get; set; }
        public Square Right { get; set; }
        public Square Up { get; set; }
        public Square Down { get; set; }
        
        public SquareObject SquareObject { get; set; }

        public bool CrateOnGoal()
        {
            if(this.SquareObject is Goal && !(this.SquareObject.InUseBy() is Crate))
            {
                return false;
            }
            return true;
        }
    }
}