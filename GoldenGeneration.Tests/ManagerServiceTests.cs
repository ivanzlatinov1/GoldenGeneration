using GoldenGeneration.Infrastructure.Entities;
using GoldenGeneration.Infrastructure.Entities.JoinedEntities;
using GoldenGeneration.Infrastructure.Repositories;
using GoldenGeneration.Infrastructure.Repositories.Readers;
using GoldenGeneration.Services.Mappers;
using Microsoft.EntityFrameworkCore;

namespace GoldenGeneration.Tests;

public class ManagerServiceTests
{
    private readonly ManagerService _service;
    private readonly UnitOfWork _unitOfWork = Substitute.For<UnitOfWork>();
    private readonly Writes<Manager> _writes = Substitute.For<Writes<Manager>>();
    private readonly ManagerReads _reads = Substitute.For<ManagerReads>();
    private readonly Manager[] _managers = [
        new()
        {
            Id = "1231233123",
            Age = 60,
            FirstName = "Alex",
            LastName = "Ferguson",
            Nationality = "Scottish",
            ManagerClubs = new List<ManagerClub>()
        },
        new()
        {
            Id = "21231233123",
            Age = 58,
            FirstName = "Jurgen",
            LastName = "Klopp",
            Nationality = "German",
            ManagerClubs = new List<ManagerClub>()
        },
        new()
        {
            Id = "31231233123",
            Age = 47,
            FirstName = "Jose",
            LastName = "Mourinho",
            Nationality = "Portuguese",
            ManagerClubs = new List<ManagerClub>()
        }
    ];

    public ManagerServiceTests()
    {
        _service = new ManagerService(_unitOfWork, _writes, _reads);
    }

    [Fact]
    public async Task GetAllAsync_Should_CallReads()
    {
        // Arrange
        _reads.AllAsync().Returns(_managers);

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
        _reads.SingleByIdAsync(id).Returns(_managers.First(x => x.Id == id));

        // Act
        await _service.GetByIdAsync(id);

        // Assert
        await _reads.Received(1).SingleByIdAsync(id);
    }

    [Fact]
    public async Task AddAsync_Should_CallWritesAndUnitOfWork()
    {
        // Arrange
        _writes.AddAsync(Arg.Any<Manager>()).Returns(_managers.Last());

        // Act
        await _service.AddAsync(_managers.Last().ToModel());

        // Assert
        await _writes.Received(1).AddAsync(Arg.Any<Manager>());
        await _unitOfWork.Received(1).SaveChangesAsync();
    }

    [Fact]
    public async Task RemoveAsync_Should_CallReadsWritesAndUnitOfWork()
    {
        // Arrange
        var id = "1231233123";
        _reads.SingleByIdAsync(id).Returns(_managers.First(x => x.Id == id));

        // Act
        await _service.RemoveAsync(id);

        // Assert
        await _reads.Received(1).SingleByIdAsync(id);
        _writes.Received(1).Remove(Arg.Any<Manager>());
        await _unitOfWork.Received(1).SaveChangesAsync();
    }
}