using System;
using System.Collections.Generic;
using System.Text;

namespace CH16Q02
{
    internal class Position
    {
        public int X;
        public int Y;

        public void Move(int dx, int dy)
        {
            X += dx;
            Y += dy;
        }
    }
}
