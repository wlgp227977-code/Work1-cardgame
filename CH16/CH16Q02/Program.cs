using System;
using CH16Q02;

Position first = new Position();                // A의 X와 Y좌표 입력
Console.Write("A의 X: ");
first.X = int.Parse(Console.ReadLine());
Console.Write("A의 Y: ");
first.Y = int.Parse(Console.ReadLine());

Position second = new Position();               // B의 X와 Y좌표 입력
Console.Write("B의 X: ");
second.X = int.Parse(Console.ReadLine());
Console.Write("B의 Y: ");
second.Y = int.Parse(Console.ReadLine());

Console.Write("선택 번호: ");                   // 선택할 번호 입력
int choice = int.Parse(Console.ReadLine());

Console.Write("X 이동량: ");                   // X와 Y 이동량 입력
int dx = int.Parse(Console.ReadLine());
Console.Write("Y 이동량: ");
int dy = int.Parse(Console.ReadLine());

Position selected = choice == 0 ? first : second;   // 선택한 번호가 0이면 A, 1이면 B
selected.Move(dx, dy);                              // 입력한 이동량만큼 움직이는 이동량 함수

Console.WriteLine($"A: {first.X}, {first.Y}");          // 결과
Console.WriteLine($"B: {second.X}, {second.Y}");
Console.WriteLine($"선택은 A와 같은 객체: {selected == first}");
