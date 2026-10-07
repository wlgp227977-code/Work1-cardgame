using System;
using CH16Q01;

// 두 강좌의 잔여 좌석

// 오전 강좌의 정원, 현재 신청인원 // 오후 강좌의 정원, 현재 신청인원. 오후 추가 신청인원입력
// 정원은 0~20, 현재 인원은 0~해당정원, 추가 신청인원은 -1~20

// 두 강좌에 각각 신청한 뒤 성공여부, 잔여좌석과 잔여좌석의 합계 출력

// 오전 강좌 정원: 10
// 오전 현재 신청 인원: 7
// 오후 강좌 정원: 8
// 오후 현재 신청 인원: 2
// 오전 추가 신청 인원: 3
// 오후 추가 신청 인원: 7

Course morning = new Course();
Console.Write("오전 강좌 정원: ");
morning.Capacity = int.Parse(Console.ReadLine());
Console.Write("오전 현재 신청 인원: ");
morning.Enrolled = int.Parse(Console.ReadLine());

Console.Write("오전 추가 신청 인원: ");
int addMorning = int.Parse(Console.ReadLine());


Course afternoon = new Course();
Console.Write("오후 강좌 정원: ");
afternoon.Capacity = int.Parse(Console.ReadLine());
Console.Write("오후 현재 신청 인원: ");
afternoon.Enrolled = int.Parse(Console.ReadLine());

Console.Write("오후 추가 신청 인원: ");
int addAfternoon = int.Parse(Console.ReadLine());


Console.Write("오전: ");
if ()




