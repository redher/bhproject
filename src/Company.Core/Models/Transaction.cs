using Company.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Core.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public Account? Account { get; set; }
        public decimal Value { get; set; }
    }
}
