﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public class Empty : ImmovableObject
    {
        public Empty(Square s) : base(s)
        {
            this.icon = ' ';
        }
    }
}
