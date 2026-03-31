using System.Text.Json;
using System.Text.Json.Nodes;
using System.IO;

if (args.Length < 3)
{
    Console.WriteLine("Использование: dotnet run <путь_к_values.json> <путь_к_tests.json> <путь_к_отчету.json>");
    return;
}

string inputValues = args[0];
string inputTest = args[1];
string output = args[2];

if (!File.Exists(inputValues))
{
    Console.WriteLine($"Файл не найден: {inputValues}");
    return;
}

if (!File.Exists(inputTest))
{
    Console.WriteLine($"Файл не найден: {inputTest}");
    return;
}

var node1 = JsonNode.Parse(File.ReadAllText(inputValues));
var node2 = JsonNode.Parse(File.ReadAllText(inputTest));

bool node1HasValues = node1["values"] != null;
bool node2HasTests = node2["tests"] != null;
if (!node1HasValues)
{
    Console.WriteLine("Первый файл не содержит структуру Values");
    return;
}
if (!node2HasTests)
{
    Console.WriteLine("Второй файл не содержит структуру Tests");
    return;
}

File.Copy(inputTest, output, overwrite: true);

var values = JsonNode.Parse(File.ReadAllText(inputValues));
var report = JsonNode.Parse(File.ReadAllText(output));

var valueMap = values["values"].AsArray()
    .ToDictionary(x => (int)x["id"], x => (string)x["value"]);

Fill(report["tests"].AsArray());

File.WriteAllText(output, report.ToJsonString(new JsonSerializerOptions { WriteIndented = true }));
void Fill(JsonArray items)
{
    foreach (var item in items)
    {
        if (item == null) continue;

        int id = (int)item["id"];

        if (valueMap.TryGetValue(id, out var val))
        {
            item["value"] = val;
        }

        if (item["values"] is JsonArray nested)
        {
            Fill(nested);
        }
    }
}
