using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicingSystem.Data.Constants
{
    public static class Strings
    {
        public const string WORKSHEET_NAME = "Faktura";
        public const string FONT = "Arial CE";
        public const string INVOICE_HEADER = "Faktura";

        public const string IN_CAPTION = "IČ";

        // Contractor section
        public const string CONTRACTOR_CAPTION = "Dodavatel";
        public const string CONTRACTOR_NAME_CAPTION = "Vaše jméno";
        public const string CONTRACTOR_STREET_CAPTION = "Ulice, č.p.";
        public const string CONTRACTOR_ZIPCODE_CAPTION = "PSČ, město";
        public const string VAT_PAYER = "Plátce DPH";
        public const string NOT_A_VAT_PAYER = "Neplátce DPH";
        public const string CONTRACTOR_CITY_OF_EVIDENCE_CAPTION = "Podnikatel zapsán v živ. rejstříku MŮ";

        // Customer section
        public const string CUSTOMER_CAPTION = "Odběratel";
        public const string CUSTOMER_VATIN_CAPTION = "DIČ";
    }
}
