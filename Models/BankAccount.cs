using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountSystem.Models
{
    internal class BankAccount
    {
        public int AccountNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public double Balance { get; set; }
    }
}
