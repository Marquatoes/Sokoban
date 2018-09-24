using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Field
    {
        public List<Square> vakken;
        public Field()
        {
            vakken = new List<Square>();
        }

        public void MoveCrate()
        {
            throw new System.NotImplementedException();
        }
    }
}