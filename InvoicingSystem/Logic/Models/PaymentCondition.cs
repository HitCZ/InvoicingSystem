using InvoicingSystem.Enumerations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using InvoicingSystem.Data.Extensions;
using System.ComponentModel.DataAnnotations;

namespace InvoicingSystem.Models {
    public class PaymentCondition {
        public int Id { get; set; }
        [NotMapped]
        [Required]
        public PaymentMethod PaymentMethod { get; set; }

        [Column("PaymentMethod")]
        public string PaymentMethodString {
            get {
                if (PaymentMethod == PaymentMethod.BankTransfer)
                    return "Převodem";
                else
                    return "Hotově";
            }
            set { PaymentMethod = value.ParseEnum<PaymentMethod>(); }
        }

        public string BankConnection { get; set; } = string.Empty;
        public string AccountNumber { get; set; } = string.Empty;
        public string VariableSymbol { get; set; } = string.Empty;
        [Required]
        public DateTime DateOfIssue { get; set; }
        [Required]
        public DateTime DueDate { get; set; }

        public override string ToString() {
            return PaymentMethodString;
        }
    }
}
