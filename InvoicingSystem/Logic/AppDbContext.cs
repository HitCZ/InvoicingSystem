using System.Data.Entity;
using InvoicingSystem.Models;

namespace InvoicingSystem.Logic
{
    public class AppDbContext : DbContext {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Contractor> Contractors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<PaymentCondition> PaymentConditions { get; set; }
    }
}
