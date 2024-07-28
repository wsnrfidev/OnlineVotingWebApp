using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace OnlineVotingApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet untuk tabel tambahan
        public DbSet<Vote> Votes { get; set; }
        public DbSet<Candidate> Candidates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Sesuaikan nama tabel dan kolom untuk menghindari masalah sintaks
            modelBuilder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable("AspNetRoles");
                entity.Property(e => e.Name).HasMaxLength(256);
            });

            // Konfigurasi tabel Candidates
            modelBuilder.Entity<Candidate>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(500);
            });
        }
    }

    // Entitas Vote
    public class Vote
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int CandidateId { get; set; }

        // Navigasi properti
        public IdentityUser User { get; set; }
        public Candidate Candidate { get; set; }
    }

    // Entitas Candidate
    public class Candidate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Navigasi properti
        public ICollection<Vote> Votes { get; set; }
    }
}
