using System;
using System.Collections.Generic;

if (args.Length != 4)
{
    Console.WriteLine("Ошибка: требуется 4 аргумента");
    Console.WriteLine("Использование: dotnet run <n> <m> <n1> <m1>");
    return;
}

if (!int.TryParse(args[0], out int n) ||
    !int.TryParse(args[1], out int m) ||
    !int.TryParse(args[2], out int n1) ||
    !int.TryParse(args[3], out int m1))
{
    Console.WriteLine("Ошибка: все значения должны быть целыми числами");
    return;
}

if (n <= 0 || m <= 0 || n1 <= 0 || m1 <= 0)
{
    Console.WriteLine("Ошибка: все значения должны быть положительными");
    return;
}

if (m > n || m1 > n1)
{
    Console.WriteLine("Ошибка: Интервал обхода не может быть больше длины кругового массива");
    return;
}

List<int> ans = [];
List<int> ans1 = [];
int pos = 0;
int pos1 = 0;

do
{
    ans.Add(pos + 1);
    pos = (pos + m - 1) % n;
}
while (pos != 0);

do
{
    ans1.Add(pos1 + 1);
    pos1 = (pos1 + m1 - 1) % n1;
}
while (pos1 != 0);

ans.AddRange(ans1);
Console.WriteLine(string.Concat(ans));
