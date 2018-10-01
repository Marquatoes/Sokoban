using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public class MovableObject : SquareObject
    {
        public MovableObject(Square s) : base(s)
        {

        }

        public Square Move()
        {
            throw new NotImplementedException();
        }
    }
}
