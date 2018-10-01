﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Wall : ImmovableObject
    {
        public Wall(Square s) : base(s)
        {
            this.icon = '#';
        }
    }
}