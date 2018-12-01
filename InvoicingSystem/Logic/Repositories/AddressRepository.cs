using System;
using System.Collections.Generic;
using System.Linq;
using InvoicingSystem.Logic.Repositories.Interfaces;
using InvoicingSystem.Models;

namespace InvoicingSystem.Logic.Repositories {
    public class AddressRepository : Repository<Address>, IAddressRepository {

        public AddressRepository(AppDbContext context) : base(context) {
        }
        
        public AppDbContext AppDbContext => Context as AppDbContext;

        public IEnumerable<Address> GetAddressesByCity(string city, IEnumerable<Address> filteredAddresses = null) {
            return GetCorrectSet(filteredAddresses)
                   .Where(a => a.City.Equals(city, StringComparison.OrdinalIgnoreCase))
                   .ToList();
        }

        public IEnumerable<Address> GetAddressesByStreet(string street, IEnumerable<Address> filteredAddresses = null) {
            return GetCorrectSet(filteredAddresses)
                   .Where(a => a.Street.Equals(street, StringComparison.OrdinalIgnoreCase))
                   .ToList();
        }
        public IEnumerable<Address> GetAddressesByZipCode(int zipcode, IEnumerable<Address> filteredAddresses = null) {
            return GetCorrectSet(filteredAddresses).Where(a => a.ZipCode == zipcode).ToList();
        }
    }
}
