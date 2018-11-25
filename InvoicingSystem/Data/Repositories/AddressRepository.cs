using InvoicingSystem.Data.Repositories.Interfaces;
using InvoicingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InvoicingSystem.Data.Repositories {
    public class AddressRepository : Repository<Address>, IAddressRepository {
        private readonly IEnumerable<Address> allAddresses;

        public AddressRepository(AppDbContext context) : base(context) {
            allAddresses = AppDbContext.Addresses;
        }
        
        public AppDbContext AppDbContext {
            get {
                return _context as AppDbContext;
            }
        }

        public IEnumerable<Address> GetAddressesByCity(string city, IEnumerable<Address> filteredAddresses = null) {
            return GetCorrectSet(filteredAddresses)
                .Where(a => a.City.Equals(
                    city, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public IEnumerable<Address> GetAddressesByStreet(string street, IEnumerable<Address> filteredAddresses = null) {
            return GetCorrectSet(filteredAddresses)
                .Where(a => a.Street.Equals(
                    street, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
        public IEnumerable<Address> GetAddressesByZipCode(int zipcode, IEnumerable<Address> filteredAddresses = null) {
            return GetCorrectSet(filteredAddresses)
                   .Where(a => a.ZipCode == zipcode).ToList();
        }
    }
}
