﻿using Muzzo.Main.Models;
using System.Data.Entity.ModelConfiguration;

namespace Muzzo.DAL.EntityConfigurations
{
    public class GigConfiguration : EntityTypeConfiguration<Gig>
    {
        public GigConfiguration()
        {
            Property(g => g.ArtistId).IsRequired();

            Property(g => g.GenreId).IsRequired();

            Property(g => g.Venue).IsRequired().HasMaxLength(255);

            HasMany(a => a.Attendees).WithRequired(g => g.Gig).WillCascadeOnDelete(false);
        }



    }
}