using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Vloer
    {
        private List<Vak> vakken;
        public Vloer()
        {
            vakken = new List<Vak>();
        }

        public Kist Kist
        {
            get => default(Kist);
            set
            {
            }
        }

        public void MoveCrate()
        {
            throw new System.NotImplementedException();
        }
    }
}