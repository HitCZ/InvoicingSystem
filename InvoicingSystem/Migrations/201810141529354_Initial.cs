namespace InvoicingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street = c.String(nullable: false),
                        BuildingNumber = c.String(nullable: false),
                        City = c.String(nullable: false),
                        ZipCode = c.Int(nullable: false),
                        Country = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contractors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        CityOfEvidence = c.String(nullable: false),
                        IsVatPayer = c.Boolean(nullable: false),
                        IdAddress = c.Int(nullable: false),
                        IN = c.Int(nullable: false),
                        VATIN = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.IdAddress, cascadeDelete: false)
                .Index(t => t.IdAddress);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CorporationName = c.String(nullable: false),
                        IdAddress = c.Int(nullable: false),
                        IN = c.Int(nullable: false),
                        VATIN = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.IdAddress, cascadeDelete: false)
                .Index(t => t.IdAddress);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdContractor = c.Int(nullable: false),
                        IdCustomer = c.Int(nullable: false),
                        IdPaymentCondition = c.Int(nullable: false),
                        InvoiceNumber = c.Int(nullable: false),
                        JobDescription = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contractors", t => t.IdContractor, cascadeDelete: false)
                .ForeignKey("dbo.Customers", t => t.IdCustomer, cascadeDelete: false)
                .ForeignKey("dbo.PaymentConditions", t => t.IdPaymentCondition, cascadeDelete: false)
                .Index(t => t.IdContractor)
                .Index(t => t.IdCustomer)
                .Index(t => t.IdPaymentCondition);
            
            CreateTable(
                "dbo.PaymentConditions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PaymentMethod = c.String(nullable: false),
                        BankConnection = c.String(),
                        AccountNumber = c.String(),
                        VariableSymbol = c.String(),
                        DateOfIssue = c.DateTime(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoices", "IdPaymentCondition", "dbo.PaymentConditions");
            DropForeignKey("dbo.Invoices", "IdCustomer", "dbo.Customers");
            DropForeignKey("dbo.Invoices", "IdContractor", "dbo.Contractors");
            DropForeignKey("dbo.Customers", "IdAddress", "dbo.Addresses");
            DropForeignKey("dbo.Contractors", "IdAddress", "dbo.Addresses");
            DropIndex("dbo.Invoices", new[] { "IdPaymentCondition" });
            DropIndex("dbo.Invoices", new[] { "IdCustomer" });
            DropIndex("dbo.Invoices", new[] { "IdContractor" });
            DropIndex("dbo.Customers", new[] { "IdAddress" });
            DropIndex("dbo.Contractors", new[] { "IdAddress" });
            DropTable("dbo.PaymentConditions");
            DropTable("dbo.Invoices");
            DropTable("dbo.Customers");
            DropTable("dbo.Contractors");
            DropTable("dbo.Addresses");
        }
    }
}
