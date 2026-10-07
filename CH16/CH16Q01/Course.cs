using System;
using System.Collections.Generic;
using System.Text;

namespace CH16Q01
{
    internal class Course
    {
        public string Name;

        public int Capacity;

        public int Enrolled;

        public bool TryEnroll(int count)
        {
            if (count > 0 && count + Enrolled <= Capacity)
            {
                Enrolled = Enrolled + count;
                return true;
            }
            else
            {                
                return false;
            }
        }

        public int GetRemaining()
        {
            return Capacity - Enrolled;
        }



    }
}
