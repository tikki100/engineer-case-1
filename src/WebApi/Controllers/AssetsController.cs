using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Core.Services;
using Core.Interfaces;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AssetsController : ControllerBase
{
    private readonly ILogger<AssetsController> _logger;
    private readonly IAssetService _assetService;

    public AssetsController(ILogger<AssetsController> logger, IAssetService assetService) {
        _logger = logger;
        _assetService = assetService ?? throw new ArgumentNullException(nameof(assetService));
    }

    [HttpGet("{id}/download")]
    public async Task<IActionResult> GetAssetDownload(string id)
    {
        try
        {
            var fileStream = await this._assetService.DownloadAssetAsync(id);

            return File(fileStream, "image/jpeg");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Unable to retrive asset filedata: {id}");
            return Problem("Unable to get the file");
        }
    }
}

