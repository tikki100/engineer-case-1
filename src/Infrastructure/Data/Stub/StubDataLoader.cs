using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Text.Json.Serialization;

using Core.Entities;

namespace Infrastructure.Data.Stub;

public class StubDataLoader
{
    public ICollection<Briefing> Briefings { get; private set; } = [];
    public ICollection<Asset> Assets { get; private set; }  = [];
    public ICollection<ContentDistribution> ContentDistributions { get; private set; }  = [];

    public StubDataLoader()
    {
        LoadData();
    }

    private void LoadData()
    {
        var jsonFilePath = Path.Combine(AppContext.BaseDirectory, "Data", "Stub", "StubData");
        var assetJsonFilePath = Path.Combine(jsonFilePath, "AssetMetadata.json");
        var briefingJsonFilePath = Path.Combine(jsonFilePath, "AssetMetadata.json");
        var contentDistributionJsonFilePath = Path.Combine(jsonFilePath, "AssetMetadata.json");

        var assetJson = File.Exists(assetJsonFilePath) ? File.ReadAllText(assetJsonFilePath) : "[]";
        var briefingJson = File.Exists(briefingJsonFilePath) ? File.ReadAllText(briefingJsonFilePath) : "[]";
        var contentDistributionJson = File.Exists(contentDistributionJsonFilePath) ? File.ReadAllText(contentDistributionJsonFilePath) : "[]";

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
        };

        Assets = JsonSerializer.Deserialize<List<Asset>>(assetJson, options) ?? new List<Asset>();
        Briefings = JsonSerializer.Deserialize<List<Briefing>>(briefingJson, options) ?? new List<Briefing>();
        ContentDistributions = JsonSerializer.Deserialize<List<ContentDistribution>>(contentDistributionJson) ?? new List<ContentDistribution>();
    }
}
