﻿using System.ComponentModel.DataAnnotations;

namespace GoldenGeneration.Services.Models
{
    public class PositionModel
    {
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }
        [StringLength(3, MinimumLength = 2)]
        public string Abbreviation { get; set; }
    }
}