using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreBasics.ValueObjects;

namespace EFCoreBasics.Domain
{
    public class Invoice
    {
        public int Id {get; set;}
        public int CustomerId {get; set;}
        public Customer Customer {get; set;}
        public DateTime Date {get; set;}
        public string Info {get; set;}
        public ICollection<InvoiceItem> Items {get; set;}
        public decimal Rate {get; set;}
        public decimal Amount {get; set;}
        public InvoiceStatus Status {get; set;}

    }
}