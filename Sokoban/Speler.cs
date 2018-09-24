using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Speler
    {
        public Vloer Vloer
        {
            get => default(Vloer);
            set
            {
            }
        }

        public Vorkheftruck Vorkheftruck
        {
            get => default(Vorkheftruck);
            set
            {
            }
        }

        public void MoveTruck(Vak oldlocation, string direcetion)
        {
            throw new System.NotImplementedException();
        }
    }
}