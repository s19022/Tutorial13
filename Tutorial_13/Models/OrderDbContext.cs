using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial_13.DTOs.Request;
using Tutorial_13.DTOs.Responce;

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

        public List<OrderResponce> GetListOfOrders(OrderRequest request)
        {
            string name = request.Name;
            if (name == null) name = "";

            return Order.Join(Confectionery_Order,
                order => order.IdOrder,
                con_order => con_order.IdOrder,
                (order, con_order) => new OrderResponce()
                {
                    IdOrder = order.IdOrder,
                    DateAccepted = order.DateAccepted,
                    DateFinished = order.DateFinished,
                    Notes = order.Notes,
                    IdClient = order.IdClient,
                    IdConfectionery = con_order.IdConfectionary
                }).Where(resp => Customer.Where(customer => customer.Name.Contains(name)).Select(cust => cust.IdCustomer)
                .Contains(resp.IdClient)).ToList();

        }

    }
}
