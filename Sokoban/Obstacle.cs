using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public abstract class Obstacle
    {
        private Square square;

        public bool canMove;

        public Obstacle(Square s)
        {
            this.square = s;
        }

        public Square Square
        {
            get => default(Square);
            set
            {
            }
        }
    }
}