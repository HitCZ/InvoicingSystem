﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using InvoicingSystem.Logic.Repositories.Interfaces;
using InvoicingSystem.Models;

namespace InvoicingSystem.Logic.Repositories {
    public class CustomerRepository : Repository<Customer>, ICustomerRepository {
        private readonly IEnumerable<Customer> allCustomers;

        public CustomerRepository(DbContext context) : base(context) {
            allCustomers = AppDbContext.Customers.Include(c => c.Address);
        }

        public AppDbContext AppDbContext => Context as AppDbContext;

        public Customer GetCustomerByIN(int IN) {
            return allCustomers.FirstOrDefault(c => c.IN == IN);
        }

        public Customer GetCustomerByVATIN(string vatin) {
            return allCustomers.FirstOrDefault(
                c => c.VATIN.Equals(vatin, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Customer> GetCustomersByAddress(Address address, IEnumerable<Customer> filteredCustomers = null) {
            return GetCorrectSet(filteredCustomers)
                   .Where(c => c.Address.Equals(address)).ToList();
        }
    }
}
