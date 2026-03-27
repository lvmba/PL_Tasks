Console.Write("Путь к файлу с координатами:");
string input1 = Console.ReadLine();
Console.Write("Путь к файлу с точками:");
string input2 = Console.ReadLine();
List<int> ans = [];

string[] ellipseParam = File.ReadAllLines(input1);
var centerCoords = ellipseParam[0].Split(' ');
double x0 = double.Parse(centerCoords[0]);
double y0 = double.Parse(centerCoords[1]);
var radiusXY = ellipseParam[1].Split(' ');
double a = double.Parse(radiusXY[0]);
double b = double.Parse(radiusXY[1]);

string[] coords = File.ReadAllLines(input2);
for (int i = 0; i < coords.Length; i++)
{
    var coordXY = coords[i].Split(' ');
    double x = double.Parse(coordXY[0]);
    double y = double.Parse(coordXY[1]);
    double ellipseCanonic = ((x - x0) * (x - x0) / (a * a)) + ((y - y0) * (y - y0) / (b * b));
    if (ellipseCanonic == 1)
        ans.Add(0);
    else if (ellipseCanonic < 1)
        ans.Add(1);
    else
        ans.Add(2);
}

ans.ForEach(Console.WriteLine);