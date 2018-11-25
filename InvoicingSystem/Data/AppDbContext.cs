using InvoicingSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicingSystem.Data {
    public class AppDbContext : DbContext {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Contractor> Contractors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<PaymentCondition> PaymentConditions { get; set; }
    }
}
