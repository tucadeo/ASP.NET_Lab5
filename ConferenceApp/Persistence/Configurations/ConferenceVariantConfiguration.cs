using System;
using ConferenceApp.Persistence.Entities;
using ConferenceApp.Persistence.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConferenceApp.Persistence.Configurations
{
    public class ConferenceVariantConfiguration : IEntityTypeConfiguration<ConferenceVariant>
    {
        public void Configure(EntityTypeBuilder<ConferenceVariant> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .IsRequired();

            builder.Property(p => p.ConferenceType)
                .IsRequired()
                .HasConversion(p => p.ToString(), p =>
                    (ConferenceType) Enum.Parse(typeof(ConferenceType), p ?? string.Empty));
        }
    }
}