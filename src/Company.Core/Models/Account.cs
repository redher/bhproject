﻿using Company.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Core.Models
{
    public class Account
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public IEnumerable<Transaction>? Transactions { get; set; }
    }
}
