namespace Core.Interfaces;

public interface IAssetDownloadRepository
{
    Task<Stream> DownloadAsync(string url);
}
