using System.Text.Json;
using System.Text.Json.Serialization;

using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Data.Stub;

public class InMemoryDataStore : IDataStore
{
    public ICollection<Asset> Assets { get; private set; }
    public ICollection<Briefing> Briefings { get; private set; }
    public ICollection<ContentDistribution> ContentDistributions { get; private set; }

    public InMemoryDataStore()
    {
        var jsonFilePath = Path.Combine(AppContext.BaseDirectory, "Data", "Stub", "StubData");
        var assetJsonFilePath = Path.Combine(jsonFilePath, "AssetMetadata.json");
        var briefingJsonFilePath = Path.Combine(jsonFilePath, "AssetMetadata.json");
        var contentDistributionJsonFilePath = Path.Combine(jsonFilePath, "AssetMetadata.json");

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
        };

        this.Assets = LoadData<Asset>(assetJsonFilePath, options);
        this.Briefings = LoadData<Briefing>(briefingJsonFilePath, options);
        this.ContentDistributions = LoadData<ContentDistribution>(contentDistributionJsonFilePath, options);
    }

    private ICollection<T> LoadData<T>(string filePath, JsonSerializerOptions? options = null)
    {
        var jsonFilePath = Path.Combine(AppContext.BaseDirectory, filePath);
        if (File.Exists(jsonFilePath))
        {
            var json = File.ReadAllText(jsonFilePath);
            return JsonSerializer.Deserialize<List<T>>(json, options) ?? new List<T>();
        }

        return new List<T>();
    }
}
