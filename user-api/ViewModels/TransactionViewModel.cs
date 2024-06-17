using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using payment_system.Entities;

namespace user_api.ViewModels
{
    public class TransactionViewModel
    {
        public User Payer { get; set; } = new User();
        
        public User Receiver { get; set; } = new User();

        public decimal Amount { get; set; } = 0;
    }
}