using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;

var parts = Console.ReadLine().Split();
int n = int.Parse(parts[0]);
int m = int.Parse(parts[1]);

List<int> roundList = Enumerable.Range(1, n).ToList();
List<int> ans = [];
int pos = 0;

do
{
    ans.Add(pos + 1);
    pos = (pos + m - 1) % n;
}
while (pos != 0);
Console.WriteLine(string.Concat(ans));