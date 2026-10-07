using System;
using CH16Q02;

Position first = new Position();
Console.Write("A의 X: ");
first.X = int.Parse(Console.ReadLine());
Console.Write("A의 Y: ");
first.Y = int.Parse(Console.ReadLine());

Position second = new Position();
Console.Write("A의 X: ");
second.X = int.Parse(Console.ReadLine());
Console.Write("A의 Y: ");
second.Y = int.Parse(Console.ReadLine());

Console.Write("선택 번호: ");
int choice = int.Parse(Console.ReadLine());
Console.Write("X 이동량: ");
first.dx = int.Parse(Console.ReadLine());
Console.Write("Y 이동량: ");
first.dy = int.Parse(Console.ReadLine());

Position selected = choice == 0 ? first : second;
selected.Move(dx, dy);

Console.WriteLine($"A: {first.X}, {first.Y}");
Console.WriteLine($"A: {second.X}, {second.Y}");
Console.WriteLine($"선택은 A와 같은 객체: {selected == first}");
