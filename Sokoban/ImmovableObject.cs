using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public abstract class ImmovableObject : SquareObject
    {
        protected ImmovableObject(Square s) : base(s) { }
    }
}
