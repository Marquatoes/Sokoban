using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser parser = new Parser();
            parser.GetLevel(1);
            //Field level = new Field();
            //level.LoadLevel(1);
            //level.ShowField();
        }
    }
}
