using InvoicingSystem.Data.Repositories.Interfaces;
using System;

namespace InvoicingSystem.Data {
    interface IUnitOfWork : IDisposable{
        IAddressRepository Addresses { get; }
        IContractorRepository Contractors { get; }
        ICustomerRepository Customers { get; }
        IPaymentConditionRepository PaymentConditions { get; }
        IInvoiceRepository Invoices { get; }

        int Complete();
    }
}
