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
                    square.SquareObject = new Wall(square);
                    Layout[row].Add(square);
                    break;
                case 'x':
                    square.SquareObject = new Goal(square);
                    Layout[row].Add(square);
                    break;
                case 'o':
                    square.SquareObject = new Crate(square);
                    Layout[row].Add(square);
                    break;
                case '@':
                    player.Truck = new Truck(square);
                    square.SquareObject = player.Truck;
                    Layout[row].Add(square);
                    break;
                case '.':
                    square.SquareObject = new Floor(square);
                    Layout[row].Add(square);
                    break;
                case ' ':
                    square.SquareObject = new Empty(square);
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
            foreach (List<Square> row in Layout)
            {
                foreach(Square square in row)
                {
                    if (square.SquareObject2 is Crate && square.SquareObject is Goal)
                    {
                        Console.Write('0');
                    }
                    else
                        Console.Write(square.SquareObject.Icon);
                }
                Console.WriteLine();
            }
        }
    }
}