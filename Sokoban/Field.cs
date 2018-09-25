using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Field
    {
        private List<List<Square>> Layout;
        private Parser parser;
        public Field()
        {
            Layout = new List<List<Square>>();
            parser = new Parser();
        }
        public void MoveCrate()
        {
            throw new System.NotImplementedException();
        }
        public void LoadLevel(int level)
        {
            List<List<char>> levelLayout = parser.GetLevel(level);
            for(int i= 0; i <levelLayout.Count; i++)
            {
                Layout.Add(new List<Square>());
                for(int j=0; j < levelLayout[i].Count; j++)
                {
                  addSquare(levelLayout[i][j], i);
                }
            }
            linkField();
        }

        private void addSquare(char type, int row)
        {
            Square square;
            switch (type)
            {    
                case '#':
                    square = new Wall();
                    Layout[row].Add(square);
                    break;
                case 'x':
                    square = new Square();
                    square.Obstacle = new Goal();
                    Layout[row].Add(square);
                    break;
                case 'o':
                    square = new Square();
                    square.Obstacle = new Crate();
                    Layout[row].Add(square);
                    break;
                case '@':
                    square = new Square();
                    square.Obstacle = new Truck();
                    Layout[row].Add(square);
                    break;
                case '.':
                    square = new Square();
                    Layout[row].Add(square);
                    break;
            }
        }
        private void linkField()
        {
            for(int i = 0; i < Layout.Count; i++)
            {
                for (int j = 0; j < Layout[i].Count; j++)
                {
                    if(i != 0 && Layout[i-1].Count > j && Layout[i-1][j] != null)
                    {
                        Layout[i][j].Up = Layout[i - 1][j];
                    }
                    if (i != Layout.Count - 1 && Layout[i + 1].Count > j && Layout[i+1][j] != null)
                    {
                        Layout[i][j].Down = Layout[i + 1][j];
                    }
                    if (j < Layout[i].Count - 1)
                    {
                        Layout[i][j].Right = Layout[i][j+1];
                    }
                    if(j > 0)
                    {
                        Layout[i][j].Left = Layout[i][j-1];
                    }
                }
            }
        }
        public void ShowField()
        {
            foreach(List<Square> row in Layout)
            {
                Square current = row[0];
                while(current != null)
                {
                    if(current is Wall)
                        Console.Write('#');
                    else if(current.Obstacle is Goal)
                        Console.Write('x');
                    else if (current.Obstacle is Crate)
                        Console.Write('o');
                    else if (current.Obstacle is Truck)
                        Console.Write('@');
                    else
                        Console.Write('.');

                    current = current.Right;
                }
                Console.WriteLine();
            }
        }
    }
}