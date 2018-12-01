using System.Collections.Generic;
using InvoicingSystem.Models;

namespace InvoicingSystem.Logic.Repositories.Interfaces {
    public interface IContractorRepository : IRepository<Contractor>{
        // ReSharper disable once InconsistentNaming
        Contractor GetContractorByIN(int n);
        IEnumerable<Contractor> GetContractorsByCityOfEvidence(string city, IEnumerable<Contractor> contractors = null);
        IEnumerable<Contractor> GetContractorsByFirstName(string firstName, IEnumerable<Contractor> contractors = null);
        IEnumerable<Contractor> GetContractorsByLastName(string lastName, IEnumerable<Contractor> contractors = null);
        IEnumerable<Contractor> GetContractorsByName(string firstName, string lastName, IEnumerable<Contractor> contractors = null);
        IEnumerable<Contractor> GetContractorsByAddress(Address address, IEnumerable<Contractor> contractors = null);
        //IEnumerable<Contractor> GetContractorsWithCustomer(Customer cu);
        // ReSharper disable once InconsistentNaming
        IEnumerable<Contractor> GetContractorsByVATPayment(bool isPayer, IEnumerable<Contractor> contractors = null);
    }
}
