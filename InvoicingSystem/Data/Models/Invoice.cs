using System.ComponentModel.DataAnnotations.Schema;

namespace InvoicingSystem.Models {
    public class Invoice {
        public int Id { get; set; }
        public int IdContractor { get; set; }
        public int IdCustomer { get; set; }
        public int IdPaymentCondition { get; set; }
        public int InvoiceNumber { get; set; }
        [ForeignKey("IdContractor")]
        public virtual Contractor Contractor { get; set; }
        [ForeignKey("IdCustomer")]
        public virtual Customer Customer { get; set; }
        [ForeignKey("IdPaymentCondition")]
        public virtual PaymentCondition PaymentCondition { get; set; }
        public string JobDescription { get; set; }
        public decimal Price { get; set; }

        public override string ToString() {
            return InvoiceNumber.ToString();
        }
    }
}
