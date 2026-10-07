using System;
using System.Collections.Generic;
using System.Text;

namespace CH16Q02
{
    internal class Position     // 위치 클래스
    {
        public int X;       // X좌표
        public int Y;       // Y좌표

        public void Move(int dx, int dy)    // 이동량 함수
        {
            X += dx;
            Y += dy;
        }
    }
}
