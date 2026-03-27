using System.Diagnostics.Metrics;

Console.Write("Путь к файлу с массивом:");
string input = Console.ReadLine();
List<int> nums = [];
int counter = 0;


string[] inputNums = File.ReadAllLines(input);
for (int i = 0; i < inputNums.Length; i++)
{
    nums.Add(int.Parse(inputNums[i]));
}
nums.Sort();


if (nums.Count % 2 != 0)
{
    int median = nums[nums.Count / 2];
    for (int i = 0; i<nums.Count; i++)
    {
        counter = counter + Math.Abs(nums[i] - median);
    }
}
else
{
    int median1 = nums[(nums.Count / 2) - 1];
    int median2 = nums[(nums.Count / 2)];
    int counter1 = 0;
    for (int i = 0; i<nums.Count; i++)
    {
        counter = counter + Math.Abs(nums[i] - median1);
        counter1 = counter1 + Math.Abs(nums[i] - median2);
    }
    if (counter1 <= counter) {
        counter = counter1;
    }
}

if (counter < 20)
{
    Console.WriteLine(counter);
}
else
{
    Console.WriteLine("20 ходов недостаточно для приведения всех элементов массива к одному числу");
}