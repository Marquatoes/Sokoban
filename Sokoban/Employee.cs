using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public class Employee : MovableObject
    {
        private bool awake = false;
        private RandomNumber rand = new RandomNumber();

        public Employee(Square s) : base(s)
        {
            this.icon = 'Z';
        }

        public override void SwapIcon()
        {
            this.icon = this.awake == true ? '$' : 'Z';
        }

        public override void Poke()
        {
            awake = true;
            this.SwapIcon();
        }

        public void Action()
        {
            if(awake == false)
            {
                var r = rand.Next(10);
                if(r == 0)
                {
                    awake = true;
                    this.SwapIcon();
                }
            }
            else
            {
                var r = rand.Next(4);
                if (r == 0)
                {
                    awake = false;
                    this.SwapIcon();
                }
                else
                {
                    var dirArr = new string[4];
                    dirArr[0] = "Up"; dirArr[1] = "Down"; dirArr[2] = "Right"; dirArr[3] = "Left";
                    r = rand.Next(4);
                    this.Move(dirArr[r]);
                }
            }
        }
    }
}
