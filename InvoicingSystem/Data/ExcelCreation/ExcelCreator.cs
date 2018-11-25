using InvoicingSystem.Models;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicingSystem.Data.ExcelCreation {
    class ExcelCreator {
        private const string worksheetName = "Faktura";
        private string path = "test.xlsx";
        private Invoice invoice;
        private Contractor contractor;
        private Customer customer;
        private PaymentCondition paymentCondition;
        /// <summary>
        ///  ((hint, position) value)
        /// </summary>
        private Dictionary<KeyValuePair<string, string>, string> coordsAndValues;
        private const string fontName = "Arial CE";
        private const float fontSize = 11f;
        private const string fakturaCell = "G3";
        private const string invoiceNumCell = "H3";
        private const string contractorCaptionCell = "C5";
        private const string contractorNameCaptionCell = "C7";
        private const string contractorNameCell = "D7";
        private const string contractorStreetCaptionCell = "C8";
        private const string contractorStreetCell = "D8";
        private const string customerCaptionCell = "G5";

        public ExcelCreator() {
            coordsAndValues
                = new Dictionary<KeyValuePair<string, string>, string>();
            InitDictionary();
        }
        public void CreateExcel(Invoice invoice) {
            this.invoice = invoice;
            this.contractor = invoice.Contractor;
            this.customer = invoice.Customer;
            this.paymentCondition = invoice.PaymentCondition;

            using (ExcelPackage excel = new ExcelPackage()) {
                excel.Workbook.Worksheets.Add(worksheetName);

                var worksheet = excel.Workbook.Worksheets[worksheetName];
                AddCells(worksheet);
                FileInfo excelFile = new FileInfo(path);
                excel.SaveAs(excelFile);
            }
        }

        private void InitDictionary() {
            FillHeaderInfo();
            FillContractorInfo();
            FillCustomerInfo();
        }

        /// <summary>
        /// Adds header info into the dictionary.
        /// </summary>
        private void FillHeaderInfo() {
            coordsAndValues.Add(new KeyValuePair<string, string>(
                "invoiceCaption", "G3"), "Faktura");
            coordsAndValues.Add(new KeyValuePair<string, string>(
                "invoiceNum", "H3"), invoice.InvoiceNumber.ToString());
        }

        /// <summary>
        /// Adds contractor info into the dictionary.
        /// </summary>
        private void FillContractorInfo() {
            coordsAndValues.Add(new KeyValuePair<string, string>(
                "contractorCaption", "C5"), "Dodavatel");
            coordsAndValues.Add(new KeyValuePair<string, string>(
                "contractorNameCaption", "C7"), "Vaše jméno");
            coordsAndValues.Add(new KeyValuePair<string, string>(
                "contractorName", "D7"), contractor.ToString());
            coordsAndValues.Add(new KeyValuePair<string, string>(
                "contractorStreetCaption", "C8"), "Ulice, č.p.");
            coordsAndValues.Add(new KeyValuePair<string, string>(
                "contractorStreet", "D8"),
                $"{contractor.Address.Street} {contractor.Address.BuildingNumber}");
            coordsAndValues.Add(new KeyValuePair<string, string>(
                "contractorZipcodeCaption", "C9"), "PSČ, město");
            coordsAndValues.Add(new KeyValuePair<string, string>(
                "contractorZipcode", "D9"),
                $"{contractor.Address.ZipCode} {contractor.Address.City}");
            coordsAndValues.Add(new KeyValuePair<string, string>(
                "contractorIN", "C11"), $"IČ: {contractor.IN}");

            // Is contractor a VAT payer??
            var temp = contractor.IsVatPayer ? "Plátce DPH" : "Neplátce DPH";
            coordsAndValues.Add(new KeyValuePair<string, string>(
                "contractorVATPayer", "C12"), temp);
            coordsAndValues.Add(new KeyValuePair<string, string>(
                "contractorCityOfEvidence", "C14"),
                $"Podnikatel zapsán v živ. rejstříku MŮ {contractor.CityOfEvidence}.");
        }

        /// <summary>
        /// Adds customer info to the dictionary.
        /// </summary>
        private void FillCustomerInfo() {
            coordsAndValues.Add(new KeyValuePair<string, string>(
                "customerCaption", "G5"), "Odběratel");
            coordsAndValues.Add(new KeyValuePair<string, string>(
                "customerCorporationName", "G7"), customer.CorporationName);
            coordsAndValues.Add(new KeyValuePair<string, string>(
                "customerStreet", "G8"), 
                $"{customer.Address.Street} {customer.Address.BuildingNumber}");
            coordsAndValues.Add(new KeyValuePair<string, string>(
                "customerZipcode", "G9"), 
                $"{customer.Address.ZipCode} {customer.Address.City}");
            coordsAndValues.Add(new KeyValuePair<string, string>(
                "customerIN", "G11"), $"IČ: {customer.IN},");
            coordsAndValues.Add(new KeyValuePair<string, string>(
                "customerVATIN", "H11"), $"DIČ: {customer.VATIN}");
        }

        private void FillPaymentConditions() {
            // TO DO
        }

        private void AddCells(ExcelWorksheet worksheet) {


            worksheet.Cells.Style.Font.Name = fontName;

            worksheet.Cells[fakturaCell].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            worksheet.Cells[fakturaCell].Style.Font.Size = 14;
            worksheet.Cells[fakturaCell].Style.Border.BorderAround(ExcelBorderStyle.Thin);
            worksheet.Cells[fakturaCell].Value = "Faktura";

            worksheet.Cells[invoiceNumCell].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            worksheet.Cells[invoiceNumCell].Value = "číslo: " + invoice.InvoiceNumber;
            worksheet.Cells[invoiceNumCell].Style.Border.BorderAround(ExcelBorderStyle.Thin);

            worksheet.Cells[contractorCaptionCell].Value = "Dodavatel";
            worksheet.Cells[customerCaptionCell].Value = "Odběratel";

            worksheet.Cells.AutoFitColumns();
        }
    }
}
