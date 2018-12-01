using System;
using System.Collections.Generic;
using InvoicingSystem.Models;

namespace InvoicingSystem.Logic.Repositories.Interfaces {
    public interface IInvoiceRepository : IRepository<Invoice>{
        Invoice GetInvoiceByNumber(int n);
        IEnumerable<Invoice> GetInvoicesByContractor(Contractor contractor, IEnumerable<Invoice> invoices = null);
        IEnumerable<Invoice> GetInvoicesWithCustomer(Customer customer, IEnumerable<Invoice> invoices = null);
        IEnumerable<Invoice> GetInvoicesWithDateOfIssue(DateTime dateOfIssue, IEnumerable<Invoice> invoices = null);
        IEnumerable<Invoice> GetInvoicesWithDueDate(DateTime dueDate, IEnumerable<Invoice> invoices = null);
        IEnumerable<Invoice> GetInvoicesWithPrice(decimal price, IEnumerable<Invoice> invoices = null);
    }
}
