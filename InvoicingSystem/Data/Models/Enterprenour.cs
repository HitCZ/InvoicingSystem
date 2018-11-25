using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicingSystem.Models {
    public abstract class Enterprenour {
        public int Id { get; set; }
        public int IdAddress { get; set; }
        [ForeignKey("IdAddress")]
        public virtual Address Address { get; set; }
        // Identification number - 'IČO'
        public int IN { get; set; }
        // Value added tax identification number - 'DIČO'
        public string VATIN { get; set; }
    }
}
