﻿using System.ComponentModel.DataAnnotations;

namespace GoldenGeneration.Infrastructure.Entities
{
    public class Kit
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string PrimaryColor { get; set; }
        [MaxLength(30)]
        public string SecondaryColor { get; set; }
        public string BadgeUrl { get; set; }
        public string Sponsor { get; set; }
    }
}
