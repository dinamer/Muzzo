﻿using Muzzo.Main.Models;
using System.Data.Entity.ModelConfiguration;

namespace Muzzo.DAL.EntityConfigurations
{
    public class GenreConfiguration : EntityTypeConfiguration<Genre>
    {
        public GenreConfiguration()
        {
            Property(g => g.Name).IsRequired().HasMaxLength(255);
        }
    }
}