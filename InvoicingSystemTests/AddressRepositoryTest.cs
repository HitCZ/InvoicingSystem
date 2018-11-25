using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InvoicingSystem.Data.Repositories;
using InvoicingSystem.Data;
using InvoicingSystem.Models;
using InvoicingSystem.Data.Repositories.Interfaces;
using Moq;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace InvoicingSystemTests {
    /// <summary>
    /// Summary description for AddressRepositoryTest
    /// </summary>
    [TestClass]
    public class AddressRepositoryTest {
        private IAddressRepository repository;
        private UnitOfWork u;
        private Address address;

        public AddressRepositoryTest() {
            var data = new List<Address> {
                new Address {
                BuildingNumber = "71",
                City = "Kyšice",
                Street = "Karlovarská",
                ZipCode = 27351
                }
            };
            repository = u.Addresses;


            //u.Addresses.Add(address);
            //u.Complete();
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext {
            get {
                return testContextInstance;
            }
            set {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void AddressByCity() {
            var city = "kyšice";
            var result = repository.GetAll().Count();


            Assert.IsTrue(result > 0);
        }
    }
}
