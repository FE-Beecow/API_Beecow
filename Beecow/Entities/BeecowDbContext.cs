using Microsoft.EntityFrameworkCore;

namespace Beecow.Entities
{
    public class BeecowDbContext : DbContext
    {
        public BeecowDbContext(DbContextOptions<BeecowDbContext> options) : base(options)
        {
            this.Database.Migrate();
        }

        public DbSet<User> User { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Business> Business { get; set; }
        public DbSet<Product>  Products { get; set; }
        public DbSet<ImagesProduct> ImagesProduct { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Business>().HasMany(a => a.Users)
                                       .WithOne(b => b.Business);
            modelBuilder.Entity<Order>().ToTable("Order")
                                        .Property(p => p.Total)
                                        .HasColumnType("decimal(18,2)");
        }
    }
}
