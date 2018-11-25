using InvoicingSystem.Data.Repositories;
using InvoicingSystem.Data.Repositories.Interfaces;

namespace InvoicingSystem.Data {
    public class UnitOfWork : IUnitOfWork {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context) {
            _context = context;

            Addresses = new AddressRepository(_context);
            Contractors = new ContractorRepository(_context);
            Customers = new CustomerRepository(_context);
            PaymentConditions = new PaymentConditionRepository(_context);
            Invoices = new InvoiceRepository(_context, PaymentConditions);
        }

        public IAddressRepository Addresses { get; private set; }

        public IContractorRepository Contractors { get; set; }

        public ICustomerRepository Customers { get; set; }

        public IPaymentConditionRepository PaymentConditions { get; set; }
        public IInvoiceRepository Invoices { get; set; }

        public int Complete() {
            return _context.SaveChanges();
        }

        public void Dispose() {
            _context.Dispose();
        }
    }
}
