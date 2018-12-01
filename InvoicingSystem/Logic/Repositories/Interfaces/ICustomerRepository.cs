using System.Collections.Generic;
using InvoicingSystem.Models;

namespace InvoicingSystem.Logic.Repositories.Interfaces {
    public interface ICustomerRepository : IRepository<Customer>{
        // ReSharper disable once InconsistentNaming
        Customer GetCustomerByIN(int IN);
        // ReSharper disable once InconsistentNaming
        // ReSharper disable once IdentifierTypo
        Customer GetCustomerByVATIN(string vatin);
        IEnumerable<Customer> GetCustomersByAddress(Address address, IEnumerable<Customer> customers = null);
    }
}
