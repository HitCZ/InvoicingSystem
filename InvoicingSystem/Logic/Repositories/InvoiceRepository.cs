
using InvoicingSystem.Data.Repositories.Interfaces;
using InvoicingSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace InvoicingSystem.Data.Repositories {
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository {
        private readonly IEnumerable<Invoice> allInvoices;

        public InvoiceRepository(DbContext context, IPaymentConditionRepository condition) : base(context) {
            allInvoices = AppDbContext.Invoices
                .Include(i => i.Contractor)
                .Include(i => i.Customer)
                .Include(i => i.PaymentCondition);
        }

        public AppDbContext AppDbContext {
            get { return _context as AppDbContext; }
        }
        public Invoice GetInvoiceByNumber(int n) {
            return allInvoices.FirstOrDefault(i => i.InvoiceNumber == n);
        }

        public IEnumerable<Invoice> GetInvoicesByContractor(Contractor c, IEnumerable<Invoice> filteredInvoices = null) {
            return GetCorrectSet(filteredInvoices)
                   .Where(i => i.Contractor.Equals(c)).ToList();
        }

        public IEnumerable<Invoice> GetInvoicesWithCustomer(Customer c, IEnumerable<Invoice> filteredInvoices = null) {
            return GetCorrectSet(filteredInvoices)
                   .Where(i => i.Customer.Equals(c)).ToList();
        }

        public IEnumerable<Invoice> GetInvoicesWithDateOfIssue(DateTime dateOfIssue, IEnumerable<Invoice> filteredInvoices = null) {
            return GetCorrectSet(filteredInvoices)
                   .Where(i => i.PaymentCondition.DateOfIssue == dateOfIssue)
                   .ToList();
        }

        public IEnumerable<Invoice> GetInvoicesWithDueDate(DateTime dueDate, IEnumerable<Invoice> filteredInvoices = null) {
            return GetCorrectSet(filteredInvoices)
                   .Where(i => i.PaymentCondition.DueDate == dueDate).ToList();
        }

        public IEnumerable<Invoice> GetInvoicesWithPrice(decimal price, IEnumerable<Invoice> filteredInvoices = null) {
            return GetCorrectSet(filteredInvoices
                   .Where(i => i.Price == price)).ToList();
        }
    }
}
