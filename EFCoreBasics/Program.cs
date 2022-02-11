using System;
using System.Collections.Generic;
using System.Linq;
using EFCoreBasics.Data;
using EFCoreBasics.Domain;
using EFCoreBasics.ValueObjects;

namespace EFCoreBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            var _context = new ApplicationContext();

            Console.WriteLine("Choose and option:\n");
            Console.WriteLine("[1] Add Customer");
            Console.WriteLine("[2] Add Item");
            Console.WriteLine("[3] Add Invoice");
            Console.WriteLine("- - - - - - - - - - - - -");

            var key = Console.ReadKey();
            switch (key.KeyChar)
            {
                case '1':
                    AddCustomer(_context);
                    break;
                case '2':
                    AddItem(_context);
                    break;
                case '3':
                    AddInvoice(_context);
                    break;                    
            }
        }

        private static void AddCustomer(ApplicationContext _context){

            var customer = new Customer
            {
                Name = "Microsoft Brazil",
                Email = "support@microsoft.com.br",
                Phone = "11 5504-2155"
            };

            _context.Set<Customer>().Add(customer);            
            var records = _context.SaveChanges();

            Console.WriteLine($"\nTotal record(s): {records}\n");
        }

        private static void AddItem(ApplicationContext _context){

            var item = new Item
            {
                Type = ItemType.Service,
                Description = "Office 365 Family",
                SalesPrice = 45m
            };

            _context.Set<Item>().Add(item);
            var records = _context.SaveChanges();

            Console.WriteLine($"\nTotal record(s): {records}\n");
        }

        private static void AddInvoice(ApplicationContext _context){

            var customer = _context.Customers.FirstOrDefault();
            var item = _context.Items.FirstOrDefault();

            var invoice = new Invoice
            {
                CustomerId = customer.Id,
                Date = DateTime.Now,
                Rate = 0m,
                Amount = item.SalesPrice,
                Info = "Console invoice added",
                Status = InvoiceStatus.InProgress,

                Items = new List<InvoiceItem>
                {
                    new InvoiceItem
                    {
                        ItemId = item.Id,
                        Quantity = 1m,
                        UnitPrice = item.SalesPrice,
                        Rate = 0m,
                        Amount = 1 * item.SalesPrice
                    }
                }
            };

            _context.Set<Invoice>().Add(invoice);
            var records = _context.SaveChanges();

            Console.WriteLine($"\nTotal record(s): {records}\n");
        }

    }
}
