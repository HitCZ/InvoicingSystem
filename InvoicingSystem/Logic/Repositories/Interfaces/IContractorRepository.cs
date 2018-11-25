using InvoicingSystem.Models;
using System.Collections.Generic;

namespace InvoicingSystem.Data.Repositories.Interfaces {
    public interface IContractorRepository : IRepository<Contractor>{
        Contractor GetContractorByIN(int n);
        IEnumerable<Contractor> GetContractorsByCityOfEvidence(string city, IEnumerable<Contractor> contractors = null);
        IEnumerable<Contractor> GetContractorsByFirstName(string firstName, IEnumerable<Contractor> contractors = null);
        IEnumerable<Contractor> GetContractorsByLastName(string lastName, IEnumerable<Contractor> contractors = null);
        IEnumerable<Contractor> GetContractorsByName(string firstName, string lastName, IEnumerable<Contractor> contractors = null);
        IEnumerable<Contractor> GetContractorsByAddress(Address address, IEnumerable<Contractor> contractors = null);
        //IEnumerable<Contractor> GetContractorsWithCustomer(Customer cu);
        IEnumerable<Contractor> GetContractorsByVATPayment(bool isPayer, IEnumerable<Contractor> contractors = null);
    }
}
