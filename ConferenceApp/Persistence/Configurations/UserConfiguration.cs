using ConferenceApp.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConferenceApp.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .IsRequired();
            
            builder.Property(p => p.ConferenceVariantId)
                .IsRequired();

            builder.Property(p => p.FirstName)
                .IsRequired();

            builder.Property(p => p.LastName)
                .IsRequired();

            builder.Property(p => p.Email)
                .IsRequired();

            builder.Property(p => p.PhotoUrl)
                .IsRequired(false);
        }
    }
}