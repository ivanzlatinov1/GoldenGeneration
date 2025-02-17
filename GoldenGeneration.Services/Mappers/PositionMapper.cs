﻿using GoldenGeneration.Infrastructure.Entities;
using GoldenGeneration.Services.Models;

namespace GoldenGeneration.Services.Mappers
{
    public static class PositionMapper
    {
        public static PositionModel ToModel(this Position entity, bool firstTime = true)
            => new()
            {
                Id = entity.Id,
                Name = entity.Name,
                Abbreviation = entity.Abbreviation
            };

        public static Position ToEntity(this PositionModel model, bool firstTime = true)
            => new()
            {
                Id = model.Id,
                Name = model.Name,
                Abbreviation = model.Abbreviation
            };
    }
}
