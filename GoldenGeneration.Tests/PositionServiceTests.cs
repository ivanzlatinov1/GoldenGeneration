using GoldenGeneration.Infrastructure.Entities;
using GoldenGeneration.Infrastructure.Repositories;
using GoldenGeneration.Infrastructure.Repositories.Readers;
using GoldenGeneration.Services.Mappers;
using Microsoft.EntityFrameworkCore;

namespace GoldenGeneration.Tests;

public class PositionServiceTests
{
    private readonly PositionService _service;
    private readonly UnitOfWork _unitOfWork = Substitute.For<UnitOfWork>();
    private readonly Writes<Position> _writes = Substitute.For<Writes<Position>>();
    private readonly PositionReads _reads = Substitute.For<PositionReads>();
    private readonly Position[] _positions = [
        new()
        {
            Id = 1,
            Name = "Forward",
            Abbreviation = "FW"
        },
        new()
        {
            Id = 2,
            Name = "Defender",
            Abbreviation = "DF"
        },
        new()
        {
            Id = 3,
            Name = "Goalkeeper",
            Abbreviation = "GK"
        }
    ];

    public PositionServiceTests()
    {
        _service = new PositionService(_unitOfWork, _writes, _reads);
    }

    [Fact]
    public async Task GetAllAsync_Should_CallReads()
    {
        // Arrange
        _reads.AllAsync().Returns(_positions);

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
        _reads.SingleByIdAsync(id).Returns(_positions.First(x => x.Id == id));

        // Act
        await _service.GetByIdAsync(id);

        // Assert
        await _reads.Received(1).SingleByIdAsync(id);
    }

    [Fact]
    public async Task AddAsync_Should_CallWritesAndUnitOfWork()
    {
        // Arrange
        _writes.AddAsync(Arg.Any<Position>()).Returns(_positions.Last());

        // Act
        await _service.AddAsync(_positions.Last().ToModel());

        // Assert
        await _writes.Received(1).AddAsync(Arg.Any<Position>());
        await _unitOfWork.Received(1).SaveChangesAsync();
    }

    [Fact]
    public async Task RemoveAsync_Should_CallReadsWritesAndUnitOfWork()
    {
        // Arrange
        var id = 1;
        _reads.SingleByIdAsync(id).Returns(_positions.First(x => x.Id == id));

        // Act
        await _service.RemoveAsync(id);

        // Assert
        await _reads.Received(1).SingleByIdAsync(id);
        _writes.Received(1).Remove(Arg.Any<Position>());
        await _unitOfWork.Received(1).SaveChangesAsync();
    }
}