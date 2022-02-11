using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreBasics.ValueObjects;

namespace EFCoreBasics.Domain
{
    public class Item
    {
        public int Id {get; set;}
        public ItemType Type {get; set;}
        public string Description {get; set;}
        public decimal SalesPrice {get; set;}
    }
}