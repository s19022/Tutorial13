using Microsoft.EntityFrameworkCore;

namespace Tutorial_13.Models
{
    public class OrderDbContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }

        public DbSet<Employee> Employee { get; set; }

        public DbSet<Order> Order { get; set; }


        public DbSet<Confectionery> Confectionery { get; set; }

        public DbSet<Confectionery_Order> Confectionery_Order { get; set; }

        public OrderDbContext()
        {

        }

        public OrderDbContext (DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Confectionery_Order>().HasKey(x => new { x.IdConfectionary, x.IdOrder });
        }

    
     

    }
}
