using GoldenGeneration.Infrastructure.Entities;
using GoldenGeneration.Infrastructure.Repositories;
using GoldenGeneration.Infrastructure.Repositories.Readers;
using GoldenGeneration.Services.Mappers;
using Microsoft.EntityFrameworkCore;

namespace GoldenGeneration.Tests;

public class ClubServiceTests
{
    private readonly ClubService _service;
    private readonly UnitOfWork _unitOfWork = Substitute.For<UnitOfWork>();
    private readonly Writes<Club> _writes = Substitute.For<Writes<Club>>();
    private readonly ClubReads _reads = Substitute.For<ClubReads>();
    private readonly Club[] _clubs = [
        new()
        {
            Name = "Aston Villa",
            Id = "1231233123",
            ImageUrl = "cr7.com",
            Manager = new Manager(),
            ChampionsLeagueTitlesCount = 1,
            LeagueWinnerTitlesCount = 1,
            Kit = new Kit(),
            KitId = 1,
            ManagerId = "1",
            League = new League(),
            LeagueId = 1
        },
        new()
        {
            Name = "Juventus",
            Id = "12312323123",
            ImageUrl = "cr7.com",
            Manager = new Manager(),
            ChampionsLeagueTitlesCount = 1,
            LeagueWinnerTitlesCount = 1,
            Kit = new Kit(),
            KitId = 1,
            ManagerId = "1",
            League = new League(),
            LeagueId = 1
        },
        new()
        {
            Name = "Burnley",
            Id = "121231233123123",
            ImageUrl = "cr7.com",
            Manager = new Manager(),
            ChampionsLeagueTitlesCount = 1,
            LeagueWinnerTitlesCount = 1,
            Kit = new Kit(),
            KitId = 1,
            ManagerId = "1",
            League = new League(),
            LeagueId = 1
        }
    ];

    public ClubServiceTests()
    {
        _service = new ClubService(_unitOfWork, _writes, _reads);
    }

    [Fact]
    public async Task GetAllAsync_Should_CallReads()
    {
        // Arrange
        _reads.AllAsync().Returns(_clubs);

        // Act
        await _service.GetAllAsync();

        // Assert
        await _reads.Received(1).AllAsync();
    }

    [Fact]
    public async Task GetByIdAsync_Should_CallReads()
    {
        // Arrange
        var id = "1231233123";
        _reads.SingleByIdAsync(id).Returns(_clubs.First(x => x.Id == id));

        // Act
        await _service.GetByIdAsync(id);

        // Assert
        await _reads.Received(1).SingleByIdAsync(id);
    }

    [Fact]
    public async Task AddAsync_Should_CallWritesAndUnitOfWork()
    {
        // Arrange
        _writes.AddAsync(Arg.Any<Club>()).Returns(_clubs.Last());

        // Act
        await _service.AddAsync(_clubs.Last().ToModel());

        // Assert
        await _writes.Received(1).AddAsync(Arg.Any<Club>());
        await _unitOfWork.Received(1).SaveChangesAsync();
    }

    [Fact]
    public async Task RemoveAsync_Should_CallReadsWritesAndUnitOfWork()
    {
        // Arrange
        var id = "1231233123";
        _reads.SingleByIdAsync(id).Returns(_clubs.First(x => x.Id == id));

        // Act
        await _service.RemoveAsync(id);

        // Assert
        await _reads.Received(1).SingleByIdAsync(id);
        _writes.Received(1).Remove(Arg.Any<Club>());
        await _unitOfWork.Received(1).SaveChangesAsync();
    }
}