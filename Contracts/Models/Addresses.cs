using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.Models
{
    public class Addresses
    {
        public IReadOnlyList<Address> Items { get; set; }
        public int Count => Items.Count;
    }
}
