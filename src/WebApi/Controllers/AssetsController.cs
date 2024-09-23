using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Core.Criterias;
using Core.Entities;
using Core.Interfaces;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AssetsController : ControllerBase
{
    private readonly ILogger<AssetsController> _logger;
    private readonly IAssetService _assetService;

    public AssetsController(ILogger<AssetsController> logger, IAssetService assetService)
    {
        _logger = logger;
        _assetService = assetService;
    }

    /// <summary>
    /// Get all assets optionally filtered by criteria.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<Asset>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAssets([FromQuery] AssetCriteria criteria, int skip = 0, int take = 10)
    {
        if (take <= 0)
        {
            return BadRequest("Take must be greater than zero.");
        }

        try
        {
            var assets = await _assetService.GetAssetsByCriteriaAsync(criteria, skip, take);

            return Ok(assets);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while retrieving assets.");
            return Problem("An error occurred while retrieving assets");
        }
    }

    /// <summary>
    /// Get an asset by its ID.
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<Asset>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAsset(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            return BadRequest("Invalid asset id");
        }

        try
        {
            var asset = await _assetService.GetAssetByIdAsync(id);
            if (asset == null)
            {
                return NotFound($"No asset found for ID {id}");
            }

            return Ok(asset);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while retrieving the asset.");
            return Problem("An error occurred while retrieving the asset");
        }
    }

    [HttpGet("{id}/download")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FileResult))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAssetDownload(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            return BadRequest("Invalid asset id");
        }

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

