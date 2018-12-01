namespace InvoicingSystem.Models {
    public class Contractor: Enterprenour {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CityOfEvidence { get; set; }
        // Value added tax payer
        public bool IsVatPayer { get; set; }

        public override string ToString() {
            return $"{FirstName} {LastName}";
        }
    }
}
