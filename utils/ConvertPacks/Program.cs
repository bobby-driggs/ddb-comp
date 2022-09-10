using ConvertPacks.Models;
using System.Text.Json;
using System.Text.RegularExpressions;

var worldDirectory = @"\\moxie\moxie-nas\foundry-data\Data\worlds\ddb-comp";
var outputDirectory = @"output";

Directory.CreateDirectory(outputDirectory);

var worldJsonPath = Path.Combine(worldDirectory, "world.json");
var worldJson = File.ReadAllText(worldJsonPath);

var worldModule = JsonSerializer.Deserialize<FoundryWorld>(worldJson);

var worldId = worldModule.id;

var replacementRegex = new Regex($"ddb-{worldId}-(.+)");

var replacementInfo = worldModule.packs
	.Select(uu => {

		var match = replacementRegex.Match(uu.name);
		var pack = match.Groups[1].Value;

		return new
		{
			Regex = new Regex(uu.name),
			ReplacementString = $"{pack}-ddb",
		};
	})
	.ToList();

foreach (var pack in worldModule.packs)
{
	Console.WriteLine($"Processing {pack.name}");

	var packDbFilePath = Path.Combine(worldDirectory, pack.path);
	var packData = File.ReadAllText(packDbFilePath);

	var newWorldData = packData.Replace("@Compendium[world.", $"@Compendium[{worldId}.");

	foreach (var info in replacementInfo)
	{
		newWorldData = info.Regex.Replace(newWorldData, info.ReplacementString);
	}

	var packMatch = replacementRegex.Match(pack.name);
	var newPackName = packMatch.Groups[1].Value;

	File.WriteAllText($"./{outputDirectory}/{newPackName}-ddb.db", newWorldData);
}




