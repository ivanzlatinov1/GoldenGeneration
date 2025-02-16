using GoldenGeneration.Infrastructure.Entities;
using GoldenGeneration.Infrastructure.Repositories;
using GoldenGeneration.Infrastructure.Repositories.Readers;
using GoldenGeneration.Services.Mappers;
using Microsoft.EntityFrameworkCore;

namespace GoldenGeneration.Tests;

public class KitServiceTests
{
    private readonly KitService _service;
    private readonly UnitOfWork _unitOfWork = Substitute.For<UnitOfWork>();
    private readonly Writes<Kit> _writes = Substitute.For<Writes<Kit>>();
    private readonly KitReads _reads = Substitute.For<KitReads>();
    private readonly Kit[] _kits = [
        new()
        {
            Id = 1,
            BadgeUrl = "badge.url",
            PrimaryColor = "Blue",
            SecondaryColor = "Red",
            Sponsor = string.Empty
        },
        new()
        {
            Id = 2,
            BadgeUrl = "badge.url",
            PrimaryColor = "Yellow",
            SecondaryColor = "Green",
            Sponsor = string.Empty
        },
        new()
        {
            Id = 3,
            BadgeUrl = "badge.url",
            PrimaryColor = "Black",
            SecondaryColor = "White",
            Sponsor = string.Empty
        }
    ];

    public KitServiceTests()
    {
        _service = new KitService(_unitOfWork, _writes, _reads);
    }

    [Fact]
    public async Task GetAllAsync_Should_CallReads()
    {
        // Arrange
        _reads.AllAsync().Returns(_kits);

        // Act
        await _service.GetAllAsync();

        // Assert
        await _reads.Received(1).AllAsync();
    }

    [Fact]
    public async Task GetByIdAsync_Should_CallReads()
    {
        // Arrange
        var id = 1;
        _reads.SingleByIdAsync(id).Returns(_kits.First(x => x.Id == id));

        // Act
        await _service.GetByIdAsync(id);

        // Assert
        await _reads.Received(1).SingleByIdAsync(id);
    }

    [Fact]
    public async Task AddAsync_Should_CallWritesAndUnitOfWork()
    {
        // Arrange
        _writes.AddAsync(Arg.Any<Kit>()).Returns(_kits.Last());

        // Act
        await _service.AddAsync(_kits.Last().ToModel());

        // Assert
        await _writes.Received(1).AddAsync(Arg.Any<Kit>());
        await _unitOfWork.Received(1).SaveChangesAsync();
    }

    [Fact]
    public async Task RemoveAsync_Should_CallReadsWritesAndUnitOfWork()
    {
        // Arrange
        var id = 1;
        _reads.SingleByIdAsync(id).Returns(_kits.First(x => x.Id == id));

        // Act
        await _service.RemoveAsync(id);

        // Assert
        await _reads.Received(1).SingleByIdAsync(id);
        _writes.Received(1).Remove(Arg.Any<Kit>());
        await _unitOfWork.Received(1).SaveChangesAsync();
    }
}