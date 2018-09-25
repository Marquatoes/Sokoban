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
            Field level = new Field();
            level.LoadLevel(1);
            level.ShowField();
            Console.ReadKey();
        }
    }
}
