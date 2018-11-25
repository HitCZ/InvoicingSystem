using InvoicingSystem.Models;
using System.Collections.Generic;

namespace InvoicingSystem.Data.Repositories.Interfaces {
    public interface IAddressRepository : IRepository<Address> {

        IEnumerable<Address> GetAddressesByCity(string city, IEnumerable<Address> addresses = null);
        IEnumerable<Address> GetAddressesByStreet(string street, IEnumerable<Address> addresses = null);
        IEnumerable<Address> GetAddressesByZipCode(int zipcode, IEnumerable<Address> addresses = null);
    }
}
