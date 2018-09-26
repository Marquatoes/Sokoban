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
        private Player player;

        public Field(Player p)
        {
            Layout = new List<List<Square>>();
            parser = new Parser();
            player = p;
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
            Square square = new Square();
            switch (type)
            {    
                case '#':
                    square.FieldObject = new Wall();
                    Layout[row].Add(square);
                    break;
                case 'x':
                    square.FieldObject = new Goal();
                    Layout[row].Add(square);
                    break;
                case 'o':
                    square.FieldObject = new Crate();
                    Layout[row].Add(square);
                    break;
                case '@':
                    player.Truck = new Truck();
                    square.FieldObject = player.Truck;
                    player.Truck.Loc = square;
                    Layout[row].Add(square);
                    break;
                case '.':
                    Layout[row].Add(square);
                    break;
                case ' ':
                    square.isNotUsable = true;
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
            Console.Clear();
            foreach(List<Square> row in Layout)
            {
                Square current = row[0];
                while(current != null)
                {
                    if (current.FieldObject is Wall)
                        Console.Write('#');
                    else if (current.FieldObject is Goal)
                        if (current.FieldObject2 != null)
                            Console.Write("0");
                        else
                            Console.Write('x');
                    else if (current.FieldObject is Crate)
                    {
                        Console.Write('o');
                    }
                    else if (current.FieldObject is Truck)
                        Console.Write('@');
                    else if (current.isNotUsable)
                        Console.Write(' ');
                    else
                        Console.Write('.');

                    current = current.Right;
                }
                Console.WriteLine();
            }
        }
    }
}