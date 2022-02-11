using System;
using System.Collections.Generic;
using System.Linq;
using EFCoreBasics.Data;
using EFCoreBasics.Domain;
using EFCoreBasics.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace EFCoreBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            var _context = new ApplicationContext();

            Console.WriteLine("Choose and option:\n");
            Console.WriteLine("[1] Customer");
            Console.WriteLine("[2] Item");
            Console.WriteLine("[3] Invoice");
            Console.WriteLine("- - - - - - - - - - - - -");

            var key = Console.ReadKey();
            switch (key.KeyChar)
            {
                case '1':
                    Console.WriteLine(" - Customer");
                    Console.WriteLine("[1] Add");
                    Console.WriteLine("[2] Read");
                    Console.WriteLine("- - - - - - - - - - - - -");
                    var subkey1 = Console.ReadKey();
                    switch (subkey1.KeyChar)
                    {
                        case '1': AddCustomer(_context); break;
                        case '2': ReadCustomer(_context); break;
                    }
                    break;  

                case '2':
                    Console.WriteLine(" - Item");
                    Console.WriteLine("[1] Add");
                    Console.WriteLine("[2] Read");
                    Console.WriteLine("- - - - - - - - - - - - -");
                    var subkey2 = Console.ReadKey();
                    switch (subkey2.KeyChar)
                    {
                        case '1': AddItem(_context); break;
                        case '2': ReadItem(_context); break;
                    }
                    break;     

                case '3':
                    Console.WriteLine(" - Item");
                    Console.WriteLine("[1] Add");
                    Console.WriteLine("[2] Read");
                    Console.WriteLine("- - - - - - - - - - - - -");
                    var subkey3 = Console.ReadKey();
                    switch (subkey3.KeyChar)
                    {
                        case '1': AddInvoice(_context); break;
                        case '2': ReadInvoice(_context); break;
                    }
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

        private static void ReadCustomer(ApplicationContext _context){

            var customer = _context.Customers
                                .Where(p => p.Id > 0)
                                .OrderBy(p => p.Id)
                                .ToList();

            Console.WriteLine("- - - - - - - - - - - - -");
            Console.WriteLine("\nLoading Items");
            Console.WriteLine("- - - - - - - - - - - - -");

            foreach(var c in customer){
                Console.WriteLine($"{c.Id} | {c.Name} | ({c.Email}) | {c.Phone}\n");
            }

            Console.WriteLine("- - - - - - - - - - - - -");
            Console.WriteLine($"{customer.Count} Customer(s) found.\n");
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

        private static void ReadItem(ApplicationContext _context){

            var item = _context.Items
                                .Where(p => p.Id > 0)
                                .OrderBy(p => p.Id)
                                .ToList();

            Console.WriteLine("- - - - - - - - - - - - -");
            Console.WriteLine("\nLoading Items");
            Console.WriteLine("- - - - - - - - - - - - -");

            foreach(var i in item){
                Console.WriteLine($"{i.Id} | {i.Description} | ({i.Type}) | ${i.SalesPrice}\n");
            }

            Console.WriteLine("- - - - - - - - - - - - -");
            Console.WriteLine($"{item.Count} Item(s) found.\n");
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

        private static void ReadInvoice(ApplicationContext _context){

            var invoice = _context.Invoices
                                .Where(i => i.Id > 0)
                                .Include(i => i.Customer)
                                .Include(i => i.Items).ThenInclude(p => p.Item)
                                .OrderBy(i => i.Id)
                                .ToList();

            Console.WriteLine("- - - - - - - - - - - - -");
            Console.WriteLine("\nLoading Items");
            Console.WriteLine("- - - - - - - - - - - - -");

            foreach(var i in invoice){
                Console.WriteLine($"{i.Id} | ({i.Date}) | {i.Customer.Name} | ${i.Amount}\n");
                Console.WriteLine("Invoice Items:\n");
                
                foreach(var l in i.Items){
                    Console.WriteLine($"    {l.Id} | ({l.Item.Description}) | ${l.UnitPrice} | {l.Quantity} | {l.Amount} \n");
                }
                Console.WriteLine("- - - - - - - - - - - - -");
            }
            Console.WriteLine($"{invoice.Count} Item(s) found.\n");
        }          

    }
}
