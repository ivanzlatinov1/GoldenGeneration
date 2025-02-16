using GoldenGeneration.Infrastructure.Entities;
using GoldenGeneration.Infrastructure.Repositories;
using GoldenGeneration.Infrastructure.Repositories.Readers;
using GoldenGeneration.Services.Mappers;
using Microsoft.EntityFrameworkCore;

namespace GoldenGeneration.Tests;

public class FootballerServiceTests
{
    private readonly FootballerService _service;
    private readonly UnitOfWork _unitOfWork = Substitute.For<UnitOfWork>();
    private readonly Writes<Footballer> _writes = Substitute.For<Writes<Footballer>>();
    private readonly FootballerReads _reads = Substitute.For<FootballerReads>();
    private readonly Footballer[] _footballers = [
        new()
        {
            FirstName = "Cristiano",
            LastName = "Ronaldo",
            Age = 40,
            ClubId = "1",
            Club = new Club(),
            Id = "1231233123",
            ImageUrl = "cr7.com",
            Nationality = "Portuguese",
            PositionId = 1,
            Position = new Position()
        },
        new()
        {
            FirstName = "Lionel",
            LastName = "Messi",
            Age = 39,
            ClubId = "2",
            Club = new Club(),
            Id = "123123123123",
            ImageUrl = "messi.com",
            Nationality = "Argentinian",
            PositionId = 1,
            Position = new Position()
        },
        new()
        {
            FirstName = "Hristo",
            LastName = "Stoichkov",
            Age = 59,
            ClubId = "2",
            Club = new Club(),
            Id = "1211223",
            ImageUrl = "hristostoichkov.com",
            Nationality = "Bulgarian",
            PositionId = 1,
            Position = new Position()
        }
    ];

    public FootballerServiceTests()
    {
        _service = new FootballerService(_unitOfWork, _writes, _reads);
    }

    [Fact]
    public async Task GetAllAsync_Should_CallReads()
    {
        // Arrange
        _reads.AllAsync().Returns(_footballers);

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
        _reads.SingleByIdAsync(id).Returns(_footballers.First(x => x.Id == id));

        // Act
        await _service.GetByIdAsync(id);

        // Assert
        await _reads.Received(1).SingleByIdAsync(id);
    }

    [Fact]
    public async Task AddAsync_Should_CallWritesAndUnitOfWork()
    {
        // Arrange
        _writes.AddAsync(Arg.Any<Footballer>()).Returns(_footballers.Last());

        // Act
        await _service.AddAsync(_footballers.Last().ToModel());

        // Assert
        await _writes.Received(1).AddAsync(Arg.Any<Footballer>());
        await _unitOfWork.Received(1).SaveChangesAsync();
    }

    [Fact]
    public async Task RemoveAsync_Should_CallReadsWritesAndUnitOfWork()
    {
        // Arrange
        var id = "1231233123";
        _reads.SingleByIdAsync(id).Returns(_footballers.First(x => x.Id == id));

        // Act
        await _service.RemoveAsync(id);

        // Assert
        await _reads.Received(1).SingleByIdAsync(id);
        _writes.Received(1).Remove(Arg.Any<Footballer>());
        await _unitOfWork.Received(1).SaveChangesAsync();
    }
}