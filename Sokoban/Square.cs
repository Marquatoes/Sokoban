using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{

    public class Square
    {


        public Square Left { get; set; }
        public Square Right { get; set; }
        public Square Up { get; set; }
        public Square Down { get; set; }
        public bool isNotUsable { get; set; }

        public Square()
        {
            isNotUsable = false;
        }
        public SquareObject SquareObject { get; set; }
        public SquareObject SquareObject2 { get; set; }

        public Square MoveObject(string direction)
        {
            Square newSquare = null;
            if(this.SquareObject is Truck)
            {
                switch(direction)
                {
                    case "UpArrow":
                        newSquare = moveToNext(this.Up,this.Up.Up);
                        break;
                    case "DownArrow":
                        newSquare = moveToNext(this.Down, this.Down.Down);
                        break;
                    case "LeftArrow":
                        newSquare = moveToNext(this.Left, this.Left.Left);
                        break;
                    case "RightArrow":
                        newSquare = moveToNext(this.Right, this.Right.Right);
                        break;
                }
            }
            return newSquare;
        }

        private Square moveToNext(Square squareTo, Square secondSquareto)
        {
            if(squareTo.SquareObject == null)
            {
                squareTo.SquareObject = this.SquareObject;
                this.SquareObject = null;
                return squareTo;
            }
            else if(squareTo.SquareObject is Wall)
            {
                //Do nothing
                
            }
            else if(squareTo.SquareObject is Crate)
            {
                if(secondSquareto.SquareObject is Crate || secondSquareto.SquareObject is Wall)
                {
                    //Do nothing
                }
                else
                {
                    if (secondSquareto.SquareObject is Goal)
                    {
                        Crate c = (Crate)squareTo.SquareObject;
                        c.Complete = true;
                        secondSquareto.SquareObject2 = squareTo.SquareObject;
                    }
                    else
                    {
                        secondSquareto.SquareObject = squareTo.SquareObject;
                    }

                    squareTo.SquareObject = this.SquareObject;
                    this.SquareObject = null;
                    return squareTo;
                }
            }
            return this;
        }

    }
}