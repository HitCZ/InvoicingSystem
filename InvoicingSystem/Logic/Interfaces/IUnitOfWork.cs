using System;
using InvoicingSystem.Logic.Repositories.Interfaces;

namespace InvoicingSystem.Logic.Interfaces {
    interface IUnitOfWork : IDisposable{
        IAddressRepository Addresses { get; }
        IContractorRepository Contractors { get; }
        ICustomerRepository Customers { get; }
        IPaymentConditionRepository PaymentConditions { get; }
        IInvoiceRepository Invoices { get; }

        int Complete();
    }
}
