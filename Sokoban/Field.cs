using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Field
    {
        private List<List<Square>> _layout;
        private Player _player;
        private Square _first;
        private List<Employee> _employees;

        public Field(Player p)
        {
            _layout = new List<List<Square>>();
            _player = p;
            _employees = new List<Employee>();
        }
        public void LoadLevel(int level)
        {
            List<List<char>> levelLayout = Parser.GetLevel(level);
            for(int i= 0; i <levelLayout.Count; i++)
            {
                _layout.Add(new List<Square>());
                for(int j=0; j < levelLayout[i].Count; j++)
                {
                  AddSquare(levelLayout[i][j], i);
                }
            }
            _first = _layout[0][0];
            LinkField();
        }

        internal bool CratesOnDestination()
        {
            for(Square first = _first; first.Down != null; first = first.Down)
            {
                for (Square firstToRight = first; firstToRight != null; firstToRight = firstToRight.Right)
                {
                    if(firstToRight.CrateOnGoal() == false)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public List<Employee> GetEmployees()
        {
            return _employees;
        }

        private void AddSquare(char type, int row)
        {
            Square square = new Square();
            switch (type)
            {    
                case '#':
                    square.SquareObject = new Wall(square);
                    _layout[row].Add(square);
                    break;
                case 'x':
                    square.SquareObject = new Goal(square);
                    _layout[row].Add(square);
                    break;
                case 'o':
                    square.SquareObject = new Floor(square, new Crate(square));
                    _layout[row].Add(square);
                    break;
                case '@':
                    _player.Truck = new Truck(square);
                    square.SquareObject = new Floor(square, _player.Truck);
                    _layout[row].Add(square);
                    break;
                case '.':
                    square.SquareObject = new Floor(square);
                    _layout[row].Add(square);
                    break;
                case ' ':
                    square.SquareObject = new Empty(square);
                    _layout[row].Add(square);
                    break;
                case '~':
                    square.SquareObject = new Trap(square);
                    _layout[row].Add(square);
                    break;
                case '$':
                    var e = new Employee(square);
                    square.SquareObject = new Floor(square, e);
                    _employees.Add(e);
                    _layout[row].Add(square);
                    break;
            }
        }
        private void LinkField()
        {
            for(int i = 0; i < _layout.Count; i++)
            {
                for (int j = 0; j < _layout[i].Count; j++)
                {
                    if(i != 0 && _layout[i-1].Count > j && _layout[i-1][j] != null)
                    {
                        _layout[i][j].Up = _layout[i - 1][j];
                    }
                    if (i != _layout.Count - 1 && _layout[i + 1].Count > j && _layout[i+1][j] != null)
                    {
                        _layout[i][j].Down = _layout[i + 1][j];
                    }
                    if (j < _layout[i].Count - 1)
                    {
                        _layout[i][j].Right = _layout[i][j+1];
                    }
                    if(j > 0)
                    {
                        _layout[i][j].Left = _layout[i][j-1];
                    }
                }
            }
        }

        public void ShowField()
        {
            Console.Clear();
            for (Square first = _first; first != null; first = first.Down)
            {
                for (Square firstToRight = first; firstToRight != null; firstToRight = firstToRight.Right)
                {
                    if (firstToRight.SquareObject.GetInUseBy() != null)
                        Console.Write(firstToRight.SquareObject.GetInUseBy().GetIcon());
                    else
                        Console.Write(firstToRight.SquareObject.GetIcon());
                }
                Console.WriteLine();
            }

            Console.WriteLine("╔═══════════════════╗");
            Console.WriteLine("║ r voor reset      ║");
            Console.WriteLine("║ s om te stoppen   ║");
            Console.WriteLine("╚═══════════════════╝");
        }
    }
}