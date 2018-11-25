using InvoicingSystem.Data.Repositories.Interfaces;
using InvoicingSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace InvoicingSystem.Data.Repositories {
    public class ContractorRepository : Repository<Contractor>, IContractorRepository {
        private readonly IEnumerable<Contractor> allContractors;

        public ContractorRepository(DbContext context) : base(context) {
            allContractors = AppDbContext.Contractors.Include(c => c.Address);
        }
        
        public AppDbContext AppDbContext {
            get {
                return _context as AppDbContext;
            }
        }

        public Contractor GetContractorByIN(int n) {
            return allContractors.FirstOrDefault(c => c.IN == n);
        }

        public IEnumerable<Contractor> GetContractorsByAddress(Address address, IEnumerable<Contractor> filteredContractors = null) {
            return GetCorrectSet(filteredContractors)
                   .Where(c => c.Address.Equals(address)).ToList();
        }

        public IEnumerable<Contractor> GetContractorsByCityOfEvidence(string city, IEnumerable<Contractor> filteredContractors = null) {
            return GetCorrectSet(filteredContractors)
                    .Where(c => c.CityOfEvidence.Equals(
                        city, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public IEnumerable<Contractor> GetContractorsByFirstName(string firstName, IEnumerable<Contractor> filteredContractors = null) {
            return GetCorrectSet(filteredContractors)
                   .Where(c => c.FirstName.Equals(
                        firstName, StringComparison.OrdinalIgnoreCase))
                   .ToList();
        }

        public IEnumerable<Contractor> GetContractorsByLastName(string lastName, IEnumerable<Contractor> filteredContractors = null) {
            return GetCorrectSet(filteredContractors)
                   .Where(c => c.LastName.Equals(
                        lastName, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public IEnumerable<Contractor> GetContractorsByName(string firstName, string lastName, IEnumerable<Contractor> filteredContractors = null) {
            return GetContractorsByFirstName(firstName, 
                    GetCorrectSet(filteredContractors))
                    .Where(c => c.LastName.Equals(
                        lastName, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public IEnumerable<Contractor> GetContractorsByVATPayment(bool isPayer, IEnumerable<Contractor> filteredContractors = null) {
            return GetCorrectSet(filteredContractors)
                   .Where(c => c.IsVatPayer == isPayer).ToList();
        }
    }
}
