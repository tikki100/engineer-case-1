using Microsoft.Extensions.Logging;

using Infrastructure.Interfaces.Repositories;

namespace Infrastructure.Repositories.Stub;

public class StubAssetDownloadRepository : IAssetDownloadRepository
{
    private readonly ILogger _logger;
    private readonly HttpClient _httpClient;

    public StubAssetDownloadRepository(HttpClient httpClient, ILogger<StubAssetDownloadRepository> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<Stream> DownloadAsync(string url)
    {
        _logger.LogInformation("Starting download from Picsum.photos.");
        try
        {
            // URL is ignored as we're stubbing pictures.
            var response = await _httpClient.GetAsync("https://picsum.photos/200/300");
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Failed to download image. Status code: {StatusCode}", response.StatusCode);
                // TODO: Handle FileNotFound
                throw new FileNotFoundException("Unable to retrieve the random image from Picsum.");
            }

            _logger.LogInformation("Download from Picsum.photos successful.");
            return await response.Content.ReadAsStreamAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while downloading the image.");
            throw;
        }
    }
}
