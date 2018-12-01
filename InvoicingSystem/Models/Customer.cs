namespace InvoicingSystem.Models {
    public class Customer : Enterprenour{
        public string CorporationName { get; set; }

        public override string ToString() {
            return CorporationName;
        }
    }
}
