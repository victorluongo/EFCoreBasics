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
            
            Console.WriteLine("\n- - - - - - - - - - - - -");
            Console.WriteLine("Choose and option:");
            Console.WriteLine("- - - - - - - - - - - - -");
            Console.WriteLine("[1] Customer");
            Console.WriteLine("[2] Item");
            Console.WriteLine("[3] Invoice");
            Console.WriteLine("[6] Add Multiple Records");
            Console.WriteLine("[7] Delete All Records");
            Console.WriteLine("[9] Exit");
            Console.WriteLine("- - - - - - - - - - - - -\n");

            var key = Console.ReadKey();
            switch (key.KeyChar)
            {
                case '1':
                    Console.WriteLine(" - Customer");
                    Console.WriteLine("[1] Add");
                    Console.WriteLine("[2] Read");
                    Console.WriteLine("[3] Update");
                    Console.WriteLine("[4] Delete");
                    Console.WriteLine("- - - - - - - - - - - - -\n");
                    var subkey1 = Console.ReadKey();
                    switch (subkey1.KeyChar)
                    {
                        case '1': AddCustomer(_context); break;
                        case '2': ReadCustomer(_context); break;
                        case '3': UpdateCustomer(_context); break;
                        case '4': DeleteCustomer(_context); break;
                    }
                    break;  

                case '2':
                    Console.WriteLine(" - Item");
                    Console.WriteLine("[1] Add");
                    Console.WriteLine("[2] Read");
                    Console.WriteLine("[3] Update");
                    Console.WriteLine("[4] Delete");
                    Console.WriteLine("- - - - - - - - - - - - -\n");
                    var subkey2 = Console.ReadKey();
                    switch (subkey2.KeyChar)
                    {
                        case '1': AddItem(_context); break;
                        case '2': ReadItem(_context); break;
                        case '3': UpdateItem(_context); break;
                        case '4': DeleteItem(_context); break;
                    }
                    break;     

                case '3':
                    Console.WriteLine(" - Invoice");
                    Console.WriteLine("[1] Add");
                    Console.WriteLine("[2] Read");
                    Console.WriteLine("[3] Update");
                    Console.WriteLine("[4] Delete");
                    Console.WriteLine("- - - - - - - - - - - - -\n");
                    var subkey3 = Console.ReadKey();
                    switch (subkey3.KeyChar)
                    {
                        case '1': AddInvoice(_context); break;
                        case '2': ReadInvoice(_context); break;
                        case '3': UpdateInvoice(_context); break;
                        case '4': DeleteInvoice(_context); break;
                    }
                    break; 

                case '6':
                    AddMultipleRecords(_context);
                    break;

                case '7':
                    DeleteAllRecords(_context);
                    break;

                case '9':
                    Environment.Exit(-1);
                    break;   
            }

            Main(args);
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

            Console.WriteLine(" - Add Customer \n- - - - - - - - - - - - -");
            Console.WriteLine($"Customer {customer.Name} added.");
        }

        private static void ReadCustomer(ApplicationContext _context){

            var customer = _context.Customers
                                .Where(p => p.Id > 0)
                                .OrderBy(p => p.Id)
                                .ToList();

            Console.WriteLine(" - Read Customer \n- - - - - - - - - - - - -");
            Console.WriteLine("Loading customers...\n");

            foreach(var c in customer){
                Console.WriteLine($"{c.Id} | {c.Name} | ({c.Email}) | {c.Phone}");
            }

            Console.WriteLine("- - - - - - - - - - - - -");
            Console.WriteLine($"{customer.Count} customer(s) found.");
        }

        private static void UpdateCustomer(ApplicationContext _context){

            var customer = _context.Customers.FirstOrDefault();

            if(customer!=null){
                                
                customer.Name += $" updated at {DateTime.Now}";
                var records = _context.SaveChanges();

                Console.WriteLine(" - Update Customer \n- - - - - - - - - - - - -");
                Console.WriteLine($"Customer {customer.Name} updated.");
            } else {
                Console.WriteLine(" - Update Customer \n- - - - - - - - - - - - -");
                Console.WriteLine("No records found.");
            }
        }  

        private static void DeleteCustomer(ApplicationContext _context){

            var customer = _context.Customers.FirstOrDefault();
            
            if(customer!=null){
                                
                _context.Set<Customer>().Remove(customer);
                var records = _context.SaveChanges();

                Console.WriteLine(" - Delete Customer \n- - - - - - - - - - - - -");
                Console.WriteLine($"Customer {customer.Name} deleted.");
            } else {
                Console.WriteLine(" - Delete Customer \n- - - - - - - - - - - - -");
                Console.WriteLine("No records found.");
            }
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

            Console.WriteLine(" - Add Item \n- - - - - - - - - - - - -");
            Console.WriteLine($"Item {item.Description} added.");
        }

        private static void ReadItem(ApplicationContext _context){

            var item = _context.Items
                                .Where(p => p.Id > 0)
                                .OrderBy(p => p.Id)
                                .ToList();

            Console.WriteLine(" - Read Items \n- - - - - - - - - - - - -");
            Console.WriteLine("Loading items...\n");

            foreach(var i in item){
                Console.WriteLine($"{i.Id} | {i.Description} | ({i.Type}) | ${i.SalesPrice}");
            }

            Console.WriteLine("- - - - - - - - - - - - -");
            Console.WriteLine($"{item.Count} item(s) found.");
        }  

        private static void UpdateItem(ApplicationContext _context){

            var item = _context.Items.FirstOrDefault();
            
            if(item!=null){
                                
                item.Description += $" updated at {DateTime.Now}";
                var records = _context.SaveChanges();

                Console.WriteLine(" - Update Item \n- - - - - - - - - - - - -");
                Console.WriteLine($"Item {item.Description} updated.");
            } else {
                Console.WriteLine(" - Update Item \n- - - - - - - - - - - - -");
                Console.WriteLine("No records found.");
            }
        }

        private static void DeleteItem(ApplicationContext _context){

            var item = _context.Items.FirstOrDefault();
            
            if(item!=null){
                
                _context.Set<Item>().Remove(item);
                var records = _context.SaveChanges();
                
                Console.WriteLine(" - Delete Item \n- - - - - - - - - - - - -");
                Console.WriteLine($"Item {item.Description} deleted.");
            } else {
                Console.WriteLine(" - Delete Item \n- - - - - - - - - - - - -");
                Console.WriteLine("No records found.");
            }
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

            Console.WriteLine(" - Add Invoice \n- - - - - - - - - - - - -");
            Console.WriteLine($"Invoice {invoice.Id} added.");
        }

        private static void ReadInvoice(ApplicationContext _context){

            var invoice = _context.Invoices
                                .Where(i => i.Id > 0)
                                .Include(i => i.Customer)
                                .Include(i => i.Items).ThenInclude(p => p.Item)
                                .OrderBy(i => i.Id)
                                .ToList();

            Console.WriteLine(" - Read Invoice \n- - - - - - - - - - - - -");
            Console.WriteLine("Loading invoices...\n");

            foreach(var i in invoice){
                Console.WriteLine($"{i.Id} | ({i.Date}) | {i.Customer.Name} | ${i.Amount}");
                Console.WriteLine("Invoice Items");
                
                foreach(var l in i.Items){
                    Console.WriteLine($"    {l.Id} | ({l.Item.Description}) | ${l.UnitPrice} | {l.Quantity} | {l.Amount} ");
                }
                Console.WriteLine("\n");
            }

            Console.WriteLine("- - - - - - - - - - - - -");
            Console.WriteLine($"{invoice.Count} invoice(s) found.");
        }

        private static void UpdateInvoice(ApplicationContext _context){

            var invoice = _context.Invoices.FirstOrDefault();
            var item = _context.Items.FirstOrDefault();

            if(invoice!=null && item!=null){

                invoice.Items = new List<InvoiceItem>
                {
                    new InvoiceItem
                    {
                        ItemId = item.Id,
                        Quantity = 1m,
                        UnitPrice = item.SalesPrice,
                        Rate = 0m,
                        Amount = 1 * item.SalesPrice
                    }
                };

                invoice.Amount += 1 * item.SalesPrice;
                var records = _context.SaveChanges();

                Console.WriteLine(" - Update Invoice \n- - - - - - - - - - - - -");
                Console.WriteLine($"Invoice {invoice.Id} updated.");
            } else {
                Console.WriteLine(" - Update Invoice \n- - - - - - - - - - - - -");
                Console.WriteLine("No records found.");
            }
        }           

        private static void DeleteInvoice(ApplicationContext _context){

            var invoice = _context.Invoices.FirstOrDefault();
            
            if(invoice!=null){
                
                _context.Set<Invoice>().Remove(invoice);
                var records = _context.SaveChanges();

                Console.WriteLine(" - Delete Invoice \n- - - - - - - - - - - - -");
                Console.WriteLine($"Invoice {invoice.Id} deleted.");
            } else {
                Console.WriteLine(" - Delete Invoice \n- - - - - - - - - - - - -");
                Console.WriteLine("No records found.");
            }
        }          

        private static void AddMultipleRecords(ApplicationContext _context)
        {

            Console.WriteLine(" - Adding multiple records...");
            Console.WriteLine("- - - - - - - - - - - - -");

            var customer = new Customer {
                Name = "Apple Store Brazil",
                Phone = "11 5180-5900",
                Email = "support@apple.com.br"
            };

            var item = new Item {

                Type = ItemType.Product,
                Description = "Macbook Pro M1",
                SalesPrice = 19799m
            };
            
            _context.AddRange(customer, item);

            var itemList = new[] {

                new Item {
                    Type = ItemType.Product,
                    Description = "iPad 11 Pro Wifi 128Gb",
                    SalesPrice = 10799m
                },

                new Item {
                    Type = ItemType.Product,
                    Description = "iPhone 13 Pro Max 128Gb",
                    SalesPrice = 10499m
                },
            };

            _context.Set<Item>().AddRange(itemList);

            var records = _context.SaveChanges();

            Console.WriteLine("4 Records added...");
        }

        private static void DeleteAllRecords(ApplicationContext _context){      

            Console.WriteLine(" - Deleting all records...");
            Console.WriteLine("- - - - - - - - - - - - -\n");
            
            var invoices = _context.Invoices.ToList();
            Console.WriteLine($"{invoices.Count} Invoice(s) deleted.");
            foreach(var invoice in invoices){
                _context.Invoices.Remove(invoice);
                _context.SaveChanges();                
            }                                                          

            var items = _context.Items.ToList();
            Console.WriteLine($"{items.Count} Item(s) deleted.");
            foreach(var item in items){
                _context.Items.Remove(item);
                _context.SaveChanges();                
            }  

            var customers = _context.Customers.ToList();
            Console.WriteLine($"{customers.Count} Customer(s) deleted.");
            foreach(var customer in customers){
                _context.Customers.Remove(customer);
                _context.SaveChanges();                
            }  

        }
    }
}