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

        public void Move(string key)
        {
            this.Square = (Square)this.Square.GetType().GetProperty(key).GetValue(this.Square);
        }
    }
}
