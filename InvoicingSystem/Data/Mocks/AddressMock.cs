using InvoicingSystem.Data.Repositories;
using InvoicingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicingSystem.Data.Mocks {
    class AddressMock {
        AppDbContext context = new AppDbContext();
        AddressRepository rep;

        public AddressMock() {
            rep = new AddressRepository(context);
            Seed();
        }

        private void Seed() {
            /*rep.CreateAddress(new Address() {
                Street = "Karlovarská",
                BuildingNumber = "71",
                City = "Kyšice",
                ZipCode = 27351
            });
            rep.CreateAddress(new Address() {
                Street = "Londýnská",
                BuildingNumber = "290/3a",
                City = "Praha",
                ZipCode = 29000
            });
            rep.CreateAddress(new Address() {
                Street = "Malé náměstí",
                BuildingNumber = "459/13",
                City = "Praha",
                ZipCode = 23001
            });*/
        }
    }
}
