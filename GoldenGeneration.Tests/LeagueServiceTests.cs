using GoldenGeneration.Infrastructure.Entities;
using GoldenGeneration.Infrastructure.Repositories;
using GoldenGeneration.Infrastructure.Repositories.Readers;
using GoldenGeneration.Services.Mappers;
using Microsoft.EntityFrameworkCore;

namespace GoldenGeneration.Tests;

public class LeagueServiceTests
{
    private readonly LeagueService _service;
    private readonly UnitOfWork _unitOfWork = Substitute.For<UnitOfWork>();
    private readonly Writes<League> _writes = Substitute.For<Writes<League>>();
    private readonly LeagueReads _reads = Substitute.For<LeagueReads>();
    private readonly League[] _leagues = [
        new()
        {
            Id = 1,
            Name = "Premier League"
        },
        new()
        {
            Id = 2,
            Name = "League 1"
        },
        new()
        {
            Id = 3,
            Name = "Bundesliga"
        }
    ];

    public LeagueServiceTests()
    {
        _service = new LeagueService(_unitOfWork, _writes, _reads);
    }

    [Fact]
    public async Task GetAllAsync_Should_CallReads()
    {
        // Arrange
        _reads.AllAsync().Returns(_leagues);

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
        _reads.SingleByIdAsync(id).Returns(_leagues.First(x => x.Id == id));

        // Act
        await _service.GetByIdAsync(id);

        // Assert
        await _reads.Received(1).SingleByIdAsync(id);
    }

    [Fact]
    public async Task AddAsync_Should_CallWritesAndUnitOfWork()
    {
        // Arrange
        _writes.AddAsync(Arg.Any<League>()).Returns(_leagues.Last());

        // Act
        await _service.AddAsync(_leagues.Last().ToModel());

        // Assert
        await _writes.Received(1).AddAsync(Arg.Any<League>());
        await _unitOfWork.Received(1).SaveChangesAsync();
    }

    [Fact]
    public async Task RemoveAsync_Should_CallReadsWritesAndUnitOfWork()
    {
        // Arrange
        var id = 1;
        _reads.SingleByIdAsync(id).Returns(_leagues.First(x => x.Id == id));

        // Act
        await _service.RemoveAsync(id);

        // Assert
        await _reads.Received(1).SingleByIdAsync(id);
        _writes.Received(1).Remove(Arg.Any<League>());
        await _unitOfWork.Received(1).SaveChangesAsync();
    }
}