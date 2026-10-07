using System;
using CH16Q08;

Console.Write("창구 수: ");
int count = int.Parse(Console.ReadLine());      // 창구 수 입력

Counter[] counters = new Counter[count];        // counters 배열객체

for  (int i = 0; i < count; i++)                // counters[i] 객체
{
    counters[i] = new Counter();
    
    Console.Write($"창구 {i + 1}: ");
    Console.Write($"이름: ");
    counters[i].Name = Console.ReadLine();
    Console.Write($"수용 한도: ");
    counters[i].Capacity = int.Parse(Console.ReadLine());
    Console.Write($"현재 대기 인원: ");
    counters[i].Waiting = int.Parse(Console.ReadLine());
    // 창구 수만큼 반복하며 창구 정보 입력
}

Console.Write("요청 수: ");
int requestCount  = int.Parse(Console.ReadLine());          // 요청 수 입력

for  (int i = 0;i < requestCount; i++)                      // 요청 수만큼 반복하여 요청인원 수용한도에 더하기
{
    Console.Write($"{i + 1}번 요청 인원: ");
    int amount = int.Parse(Console.ReadLine());         // 몇번째 요청: 요청인원수 입력

    Counter selected = null;                                // selected(선택한 창구) 객체 null임

    foreach (Counter counter in counters)           // counters 배열 객체에서 counter 객체를 하나씩 꺼냄
    {                                               // 요청인원을 입력했을때, 창구 하나씩 확인
        if (counter.CanAccept(amount) &&            // 꺼낸 창구가 수용가능하고(요청인원이 0보다 크고  
           (selected == null || counter.Waiting < selected.Waiting)) // 대기인원과의 합이 한도보다 작거나 같을때
        {                                           // && (선택한 창구가 null이거나 꺼낸 창구가 대기인원이 더 적을때 
            selected = counter;                     // 해당 창구를 선택함
        }
    }

    if (selected == null)                   // 선택을 못했을때
    {
        Console.WriteLine("배정 불가");     // 배정 불가 출력

    }
    else
    {                                       // 선택을 하면
        selected.Accept(amount);            // 대기인원에 요청인원을 더하고
        Console.WriteLine($"{selected.Name}: {selected.Waiting}");  // 선택한 창구의 이름과 현재 대기인원 출력
    }
}

Console.WriteLine("최종 대기");             // 요청수만큼 합산이 끝나고 최종 대기인원 출력
foreach (Counter counter in counters)       // counters[count] 에서 count를 차례로 꺼내어 이름과 대기인원 출력
{
    Console.WriteLine($"{counter.Name}: {counter.Waiting}");
}