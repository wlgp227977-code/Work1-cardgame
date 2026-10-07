using System;
using System.Collections.Generic;
using System.Text;

namespace CH16Q08
{
    internal class Counter
    {
        public string Name;         // 창구 이름

        public int Capacity;        // 수용 한도

        public int Waiting;         // 현재 대기 인원
        
        public bool CanAccept(int amount)       // 수용 가능한지 아닌지
        {
            return amount > 0 && Waiting + amount <= Capacity;  // 요청인원이 0보다 크고 대기인원과의 합이 한도보다 작거나 같을때
        }                                                       // true로 리턴

        public void Accept(int amount)      
        {
            if (CanAccept(amount))      // 위 조건을 만족하여 ture값으로 리턴될때 현재 대기인원에 요청인원을 더함
            {
                Waiting += amount;
            }
            
        }

    }
}
