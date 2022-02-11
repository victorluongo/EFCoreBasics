using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreBasics.Domain
{
    public class InvoiceItem
    {
        public int Id {get; set;}
        public int InvoiceId {get; set;}
        public Invoice Invoice {get; set;}
        public int ItemId {get; set;}
        public Item Item {get; set;}
        public decimal Quantity {get; set;}
        public decimal UnitPrice {get; set;}
        public decimal Rate {get; set;}
        public decimal Amount {get; set;}

    }
}