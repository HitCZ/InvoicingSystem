use InvoicingDB;
/*INSERT INTO Addresses (BuildingNumber, City, Country, Street, ZipCode)
VALUES				  ('71', 'Kyšice', 'Èeská republika', 'Karlovarská', 27351);*/
SELECT * FROM Addresses;

/*INSERT INTO Contractors (CityOfEvidence, FirstName, IdAddress, [IN], IsVatPayer, LastName, VATIN)
VALUES					('Kladno', 'Jiøí', 1, 201515, 0, 'Kocourek', 'CZ201515');*/
SELECT * FROM Contractors;

/*INSERT INTO PaymentConditions (DateOfIssue, DueDate, PaymentMethod)
VALUES						  ('2018-9-14', '2018-9-25', 'BankTransfer');*/
SELECT * FROM PaymentConditions;

/*INSERT INTO Customers (CorporationName, IdAddress, [IN], VATIN)
VALUES				  ('IZOLPRAG', 1, 215105, 'CZ215105');*/
SELECT * FROM Customers;

/*INSERT INTO Invoices (IdContractor, IdCustomer, IdPaymentCondition, InvoiceNumber, JobDescription, Price)
VALUES				 (1, 1, 1, 20180008, 'Blablabla', 30000);*/
SELECT * FROM Invoices;