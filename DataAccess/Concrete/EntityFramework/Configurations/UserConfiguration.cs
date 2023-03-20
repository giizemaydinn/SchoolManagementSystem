using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", @"dbo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName)
                .HasColumnName("FirstName")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasColumnName("LastName")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnName("Email")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.PasswordSalt)
                .HasColumnName("PasswordSalt")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(x => x.PasswordHash)
              .HasColumnName("PasswordHash")
                .HasMaxLength(500)
              .IsRequired();

            builder.Property(x => x.Status)
                .HasColumnName("Status")
                .IsRequired();
            
            

        }
    }
}
