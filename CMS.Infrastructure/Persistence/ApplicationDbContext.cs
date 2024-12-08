using CMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CMS.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        internal DbSet<Candidate> Candidates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Candidate>(entity =>
            {
                entity.HasKey(c => c.Email);

                entity.Property(c => c.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnType("nvarchar(255)");

                entity.Property(c => c.FirstName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar(100)");

                entity.Property(c => c.LastName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar(100)");

                entity.Property(c => c.PhoneNumber)
                    .HasMaxLength(15)
                    .HasColumnType("nvarchar(15)");

                entity.Property(c => c.AvailableFrom).HasColumnType("datetime2");
                entity.Property(c => c.AvailableTo).HasColumnType("datetime2");

                entity.Property(c => c.LinkedInProfileUrl)
                    .HasMaxLength(200)
                    .HasColumnType("nvarchar(200)");

                entity.Property(c => c.GithubProfileUrl)
                    .HasMaxLength(200)
                    .HasColumnType("nvarchar(200)");

                entity.Property(c => c.Comment)
                    .IsRequired(false)
                    .HasMaxLength(1000)
                    .HasColumnType("nvarchar(1000)");
            });
        }
    }
}
