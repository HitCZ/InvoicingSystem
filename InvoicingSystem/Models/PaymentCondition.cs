using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using InvoicingSystem.Logic.Constants;
using InvoicingSystem.Logic.Enumerations;
using InvoicingSystem.Logic.Extensions;

namespace InvoicingSystem.Models
{
    public class PaymentCondition
    {
        #region Properties

        public int Id { get; set; }
        [NotMapped]
        [Required]
        public PaymentMethod PaymentMethod { get; set; }

        [Column("PaymentMethod")]
        public string PaymentMethodString
        {
            get => PaymentMethod is PaymentMethod.BankTransfer
                ? Strings.PAYMENT_METHOD_TRANSFER : Strings.PAYMENT_METHOD_CASH;
            set => PaymentMethod = value.ParseEnum<PaymentMethod>();
        }

        public string BankConnection { get; set; } = string.Empty;
        public string AccountNumber { get; set; } = string.Empty;
        public string VariableSymbol { get; set; } = string.Empty;
        [Required]
        public DateTime DateOfIssue { get; set; }
        [Required]
        public DateTime DueDate { get; set; }

        #endregion Properties

        #region Overriden Methods

        public override string ToString()
        {
            return PaymentMethodString;
        }

        #endregion
    }
}
