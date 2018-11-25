using InvoicingSystem.Models;
using System.Collections.Generic;

namespace InvoicingSystem.Data.Repositories.Interfaces {
    public interface ICustomerRepository : IRepository<Customer>{
        Customer GetCustomerByIN(int IN);
        Customer GetCustomerByVATIN(string vatin);
        IEnumerable<Customer> GetCustomersByAddress(Address address, IEnumerable<Customer> customers = null);
    }
}
