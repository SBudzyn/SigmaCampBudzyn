using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework12
{
    internal class Coordinates
    {
        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }
        private int _x;

        public int X
        {
            get => _x; 
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Wrong coordinates");
                }
                _x = value; 
            }
        }
        private int _y;

        public int Y
        {
            get => _y;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Wrong coordinates");
                }
                _y = value;
            }
        }
    }
}
