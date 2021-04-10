using Microsoft.EntityFrameworkCore;

namespace Beecow.Entities
{
    public class BeecowDbContext : DbContext
    {
        public BeecowDbContext(DbContextOptions<BeecowDbContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Business> Business { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Business>().HasOne(a => a.User)
                                       .WithOne(b => b.Business)
                                       .HasForeignKey<User>(b => b.BusinessId);
            modelBuilder.Entity<Order>().ToTable("Order");
        }
    }
}
