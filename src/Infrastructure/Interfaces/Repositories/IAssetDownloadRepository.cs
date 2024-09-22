namespace Infrastructure.Interfaces.Repositories;

public interface IAssetDownloadRepository
{
    Task<Stream> DownloadAsync(string url);
}
