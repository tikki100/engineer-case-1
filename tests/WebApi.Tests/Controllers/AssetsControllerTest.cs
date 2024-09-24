using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

using Core.Entities;
using Core.Interfaces;

namespace WebApi.Controllers.Tests;

public class AssetsControllerTest
{
    private readonly Mock<ILogger<AssetsController>> _mockLogger;
    private readonly Mock<IAssetService> _mockAssetService;
    private readonly Mock<IBriefingService> _mockBriefingService;
    private readonly Mock<IContentDistributionService> _mockContentDistributionService;
    private readonly AssetsController _controller;

    public AssetsControllerTest()
    {
        _mockLogger = new Mock<ILogger<AssetsController>>();
        _mockAssetService = new Mock<IAssetService>();
        _mockBriefingService = new Mock<IBriefingService>();
        _mockContentDistributionService = new Mock<IContentDistributionService>();
        _controller = new AssetsController(_mockLogger.Object,
                                           _mockAssetService.Object,
                                           _mockBriefingService.Object,
                                           _mockContentDistributionService.Object);
    }

    [Fact]
    public async Task GetAsset_ReturnsBadRequest_WhenIdIsNullOrEmpty()
    {
        //Arange
        var assetId = string.Empty;

        // Act
        var result = await _controller.GetAsset(assetId);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal("Invalid asset id", badRequestResult.Value);
    }

    [Fact]
    public async Task GetAsset_ReturnsNotFound_WhenAssetDoesNotExist()
    {
        // Arrange
        var assetId = "nonexistent";
        _mockAssetService
            .Setup(service => service.GetAssetByIdAsync(assetId.ToUpperInvariant()))
            .ReturnsAsync((Asset?)null);

        // Act
        var result = await _controller.GetAsset(assetId);

        // Assert
        var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
        Assert.Equal($"No asset found for ID {assetId.ToUpperInvariant()}", notFoundResult.Value);
    }

    [Fact]
    public async Task GetAsset_ReturnsOk_WhenAssetExists()
    {
        // Arrange
        var assetId = "existing";
        var asset = new Asset { AssetId = assetId };
        _mockAssetService
            .Setup(service => service.GetAssetByIdAsync(assetId.ToUpperInvariant()))
            .ReturnsAsync(asset);

        // Act
        var result = await _controller.GetAsset(assetId);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(asset, okResult.Value);
    }

    [Fact]
    public async Task GetAsset_ReturnsProblem_WhenExceptionIsThrown()
    {
        // Arrange
        var assetId = "error";
        _mockAssetService.Setup(service => service.GetAssetByIdAsync(assetId.ToUpperInvariant()))
            .ThrowsAsync(new Exception("Test exception"));

        // Act
        var result = await _controller.GetAsset(assetId);

        // Assert
        var problemResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(500, problemResult.StatusCode);
        var problemDetails = Assert.IsType<ProblemDetails>(problemResult.Value);
        Assert.Equal("An error occurred while retrieving the asset", problemDetails.Detail);
    }
}
