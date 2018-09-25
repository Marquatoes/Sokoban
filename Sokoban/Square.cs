using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{

    public class Square
    {

        public Square()
        {
            isNotUsable = false;
        }
        public Obstacle Obstacle { get; set; }
        public Square Left { get; set; }

        public void MoveObject(char direction)
        {
            if(this.Obstacle is Truck)
            {
                switch(direction)
                {
                    case 'u':
                        moveToNext(this.Up,this.Up.Up);
                        break;
                    case 'd':
                        moveToNext(this.Down, this.Down.Down);
                        break;
                    case 'l':
                        moveToNext(this.Left, this.Left.Left);
                        break;
                    case 'r':
                        moveToNext(this.Right, this.Right.Right);
                        break;
                }
            }
        }

        private void moveToNext(Square squareTo, Square secondSquareto)
        {
            if(squareTo.Obstacle.Equals(null))
            {
                squareTo.Obstacle = this.Obstacle;
                this.Obstacle = null;
                squareTo.Obstacle.Square = squareTo;
            }
            else if(squareTo is Wall)
            {

            }
            else if(squareTo.Obstacle is Crate)
            {
                if(secondSquareto.Obstacle is Crate || secondSquareto is Wall)
                {

                }
                else
                {
                    squareTo.Obstacle = this.Obstacle;
                    this.Obstacle = null;
                    secondSquareto.Obstacle = squareTo.Obstacle;
                    squareTo.Obstacle = null;
                   
                }
            }
        }

        public Square Right { get; set; }
        public Square Up { get; set; }
        public Square Down { get; set; }
        public bool isNotUsable { get; set; }

        public void IsMovable()
        {
            throw new System.NotImplementedException();
        }

    }
}