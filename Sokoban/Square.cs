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
        public FieldObject FieldObject { get; set; }
        public FieldObject FieldObject2 { get; set; }

        public Square MoveObject(string direction)
        {
            Square newSquare = null;
            if(this.FieldObject is Truck)
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
            if(squareTo.FieldObject == null)
            {
                squareTo.FieldObject = this.FieldObject;
                this.FieldObject = null;
                return squareTo;
            }
            else if(squareTo.FieldObject is Wall)
            {
                //Do nothing
                
            }
            else if(squareTo.FieldObject is Crate)
            {
                if(secondSquareto.FieldObject is Crate || secondSquareto.FieldObject is Wall)
                {
                    //Do nothing
                }
                else
                {
                    if (secondSquareto.FieldObject is Goal)
                    {
                        Crate c = (Crate)squareTo.FieldObject;
                        c.Complete = true;
                        secondSquareto.FieldObject2 = squareTo.FieldObject;
                    }
                    else
                    {
                        secondSquareto.FieldObject = squareTo.FieldObject;
                    }

                    squareTo.FieldObject = this.FieldObject;
                    this.FieldObject = null;
                    return squareTo;
                }
            }
            return this;
        }

    }
}