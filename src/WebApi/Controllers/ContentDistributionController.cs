using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentDistributionController : ControllerBase
    {
        private readonly ILogger<ContentDistributionController> _logger;
        private readonly IAssetService _assetService;
        private readonly IContentDistributionService _contentDistributionService;

        public ContentDistributionController(
            ILogger<ContentDistributionController> logger,
            IAssetService assetService,
            IContentDistributionService contentDistributionService)
        {
            _logger = logger;
            _assetService = assetService;
            _contentDistributionService = contentDistributionService;
        }

        [HttpGet("{contentId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<Asset>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetContentDistributionById(string contentId)
        {
            if (string.IsNullOrEmpty(contentId))
            {
                return BadRequest("Invalid content distribution id");
            }

            var uppercaseId = contentId.ToUpper();

            try
            {
                var contentDistribution = await _contentDistributionService.GetContentDistributionByIdAsync(uppercaseId);
                if (contentDistribution == null)
                {
                    return NotFound($"No content distribution found for ID {uppercaseId}");
                }

                return Ok(contentDistribution);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving content distribution with ID: {contentId}");
                return Problem($"An error occurred while retrieving the content distribution with ID: {contentId}");
            }
        }

        [HttpGet("{contentId}/assets")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<Asset>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAssetsByContentDistributionId(string contentId)
        {
            if (string.IsNullOrEmpty(contentId))
            {
                return BadRequest("Invalid content distribution id");
            }

            var uppercaseId = contentId.ToUpper();

            try 
            {
                var assets = await _assetService.GetAssetsByContentDistributionId(uppercaseId);
                return Ok(assets);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving assets for the content distribution with ID: {contentId}");
                return Problem($"An error occurred while retrieving assets for the content distribution with ID: {contentId}");
            }

        }

    }
}