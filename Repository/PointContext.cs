namespace back_point.Repository
{
    using back_point.Models;
    using Microsoft.EntityFrameworkCore;

    public class PointContext : DbContext
    {

        public DbSet<back_point.Models.User> Users { get; set; }
        public DbSet<back_point.Models.Enterprise> Enterprises { get; set; }
        public DbSet<back_point.Models.Point> Points { get; set; }

        public PointContext(DbContextOptions<PointContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .HasAlternateKey(u => u.code);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Enterprise)
                .WithMany(e => e.Users)
                .HasForeignKey(u => u.EnterpriseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Point>()
                .HasOne(p => p.User)
                .WithMany(u => u.Points)
                .HasForeignKey(p => p.code)
                .HasPrincipalKey(u => u.code)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}