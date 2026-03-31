using System;
using System.Collections.Generic;
using System.IO;
if (args.Length < 2)
{
    Console.WriteLine("Использование: dotnet run <путь_к_файлу_эллипса> <путь_к_файлу_точек>");
return;
}

string input1 = args[0];
string input2 = args[1];

if (!File.Exists(input1))
{
    Console.WriteLine("Файл с параметрами эллипса не найден");
    return;
}

if (!File.Exists(input2))
{
    Console.WriteLine("Файл с параметрами эллипса не найден");
    return;
}

List<int> ans = [];
const decimal Epsilon = 0.0000000001m;

string[] ellipseParam = File.ReadAllLines(input1);
var centerCoords = ellipseParam[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
decimal x0 = decimal.Parse(centerCoords[0]);
decimal y0 = decimal.Parse(centerCoords[1]);
var radiusXY = ellipseParam[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
decimal a = decimal.Parse(radiusXY[0]);
decimal b = decimal.Parse(radiusXY[1]);

if (a == 0 || b == 0)
{
    Console.WriteLine("Ошибка: Радиусы не могут быть равны нулю");
    return;
}

if (a < 0)
{
    a = Math.Abs(a);
}

if (b < 0)
{
    b = Math.Abs(b);
}

string[] coords = File.ReadAllLines(input2);
for (int i = 0; i < coords.Length; i++)
{
    var coordXY = coords[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
    decimal x = decimal.Parse(coordXY[0]);
    decimal y = decimal.Parse(coordXY[1]);
    decimal ellipseCanonic = ((x - x0) * (x - x0) / (a * a)) + ((y - y0) * (y - y0) / (b * b));
    if (Math.Abs(ellipseCanonic - 1m) <= Epsilon)
        ans.Add(0);
    else if (ellipseCanonic < 1m)
        ans.Add(1);
    else
        ans.Add(2);
}

ans.ForEach(Console.WriteLine);
