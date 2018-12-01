using System;
using System.Collections.Generic;
using InvoicingSystem.Logic.Enumerations;
using InvoicingSystem.Models;

namespace InvoicingSystem.Logic.Repositories.Interfaces {
    public interface IPaymentConditionRepository : IRepository<PaymentCondition> {
        IEnumerable<PaymentCondition> GetConditionsByPaymentMethod(PaymentMethod method, IEnumerable<PaymentCondition> conditions = null);
        IEnumerable<PaymentCondition> GetConditionsByBankConnection(string connection, IEnumerable<PaymentCondition> conditions = null);
        IEnumerable<PaymentCondition> GetConditionsByAccountNumber(string accountNumber, IEnumerable<PaymentCondition> conditions = null);
        IEnumerable<PaymentCondition> GetConditionsByVariableSymbol(string symbol, IEnumerable<PaymentCondition> conditions = null);
        IEnumerable<PaymentCondition> GetConditionsByDateOfIssue(DateTime date, IEnumerable<PaymentCondition> conditions = null);
        IEnumerable<PaymentCondition> GetConditionsByDueDate(DateTime date, IEnumerable<PaymentCondition> conditions = null);
        IEnumerable<PaymentCondition> GetConditionsBetweenDueDates(DateTime start, DateTime end, IEnumerable<PaymentCondition> conditions = null);
        IEnumerable<PaymentCondition> GetConditionsBeforeDueDate(DateTime date, IEnumerable<PaymentCondition> conditions = null);
        IEnumerable<PaymentCondition> GetConditionsAfterDueDate(DateTime date, IEnumerable<PaymentCondition> conditions = null);
    }
}
