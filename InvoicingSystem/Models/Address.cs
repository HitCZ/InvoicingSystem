namespace InvoicingSystem.Models {
    public class Address {
        public int Id { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }
        public string Country { get; set; } = "Česká republika";

        public override string ToString() {
            return $"{Street} {BuildingNumber}, {ZipCode} {City}; {Country}";
        }
    }
}
