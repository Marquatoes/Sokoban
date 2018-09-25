using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{

    public class Square
    {

        public Square()
        {

        }
        public Obstacle Obstacle { get; set; }
        public Square Left { get; set; }
        public Square Right { get; set; }
        public Square Up { get; set; }
        public Square Down { get; set; }

        public void IsMovable()
        {
            throw new System.NotImplementedException();
        }

    }
}