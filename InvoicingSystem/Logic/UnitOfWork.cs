using InvoicingSystem.Logic.Interfaces;
using InvoicingSystem.Logic.Repositories;
using InvoicingSystem.Logic.Repositories.Interfaces;

namespace InvoicingSystem.Logic {
    public class UnitOfWork : IUnitOfWork {
        private readonly AppDbContext context;

        public UnitOfWork(AppDbContext context) {
            this.context = context;

            Addresses = new AddressRepository(this.context);
            Contractors = new ContractorRepository(this.context);
            Customers = new CustomerRepository(this.context);
            PaymentConditions = new PaymentConditionRepository(this.context);
            Invoices = new InvoiceRepository(this.context, PaymentConditions);
        }

        public IAddressRepository Addresses { get; private set; }

        public IContractorRepository Contractors { get; set; }

        public ICustomerRepository Customers { get; set; }

        public IPaymentConditionRepository PaymentConditions { get; set; }
        public IInvoiceRepository Invoices { get; set; }

        public int Complete() {
            return context.SaveChanges();
        }

        public void Dispose() {
            context.Dispose();
        }
    }
}
