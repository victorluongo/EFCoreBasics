using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreBasics.Domain
{
    public class Customer
    {
        public int Id { get; set;}
        public string Name {get; set;}
        public string Email {get; set;} 
        public string Phone {get; set;}

    }
}