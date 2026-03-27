using System.Text.Json;
using System.Text.Json.Nodes;

Console.Write("Путь к values.json: ");
string inputValues = Console.ReadLine();
Console.Write("Путь к tests.json: ");
string inputTest = Console.ReadLine();
Console.Write("Путь к отчету: ");
string output = Console.ReadLine();
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