using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using InvoicingSystem.Logic.Enumerations;
using InvoicingSystem.Logic.Repositories.Interfaces;
using InvoicingSystem.Models;

namespace InvoicingSystem.Logic.Repositories {
    public class PaymentConditionRepository : Repository<PaymentCondition>, IPaymentConditionRepository {

        public PaymentConditionRepository(DbContext context) : base(context) {
        }

        public AppDbContext AppDbContext => Context as AppDbContext;

        public IEnumerable<PaymentCondition> GetConditionsAfterDueDate(DateTime date, IEnumerable<PaymentCondition> filteredConditions = null) {
            return GetCorrectSet(filteredConditions)
                   .Where(p => p.DueDate > date).ToList();
        }

        public IEnumerable<PaymentCondition> GetConditionsBeforeDueDate(DateTime date, IEnumerable<PaymentCondition> filteredConditions = null) {
            return GetCorrectSet(filteredConditions)
                   .Where(p => p.DueDate < date).ToList();
        }

        public IEnumerable<PaymentCondition> GetConditionsBetweenDueDates(DateTime start, DateTime end, IEnumerable<PaymentCondition> filteredConditions = null) {
            return GetCorrectSet(filteredConditions)
                .Where(p => ((p.DueDate >= start) && p.DueDate <= end))
                .ToList();
        }

        public IEnumerable<PaymentCondition> GetConditionsByAccountNumber(string accountNumber, IEnumerable<PaymentCondition> filteredConditions = null) {
            return GetCorrectSet(filteredConditions)
                .Where(p => p.AccountNumber.Equals(accountNumber)).ToList();
        }

        public IEnumerable<PaymentCondition> GetConditionsByBankConnection(string connection, IEnumerable<PaymentCondition> filteredConditions = null) {
            return GetCorrectSet(filteredConditions)
                .Where(p => p.BankConnection.Equals(connection)).ToList();
        }

        public IEnumerable<PaymentCondition> GetConditionsByDateOfIssue(DateTime date, IEnumerable<PaymentCondition> filteredConditions = null) {
            return GetCorrectSet(filteredConditions)
                   .Where(p => p.DateOfIssue == date).ToList();
        }

        public IEnumerable<PaymentCondition> GetConditionsByDueDate(DateTime date, IEnumerable<PaymentCondition> filteredConditions = null) {
            return GetCorrectSet(filteredConditions)
                   .Where(p => p.DueDate == date).ToList();
        }

        public IEnumerable<PaymentCondition> GetConditionsByPaymentMethod(PaymentMethod method, IEnumerable<PaymentCondition> filteredConditions = null) {
            return GetCorrectSet(filteredConditions)
                   .Where(p => p.PaymentMethod == method).ToList();
        }

        public IEnumerable<PaymentCondition> GetConditionsByVariableSymbol(string symbol, IEnumerable<PaymentCondition> filteredConditions = null) {
            return GetCorrectSet(filteredConditions)
                .Where(p => p.VariableSymbol.Equals(symbol)).ToList();
        }
    }
}
