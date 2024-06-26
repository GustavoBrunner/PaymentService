using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace payment_system.Entities
{
    public class TransactionModel 
    {
        [Key]
        public string TransactionId { get; set; } = string.Empty;
        
        
        public string UserId { get; set; } = string.Empty;

        public string ReceiverId { get; set; } = string.Empty;
        
        public UserDto Payer { get; set; } = new UserDto();
        
        public UserDto Receiver { get; set; } = new UserDto();
        
        [Precision(12,2)]
        public decimal Value { get; set; } = 0;

        public bool IsFinished { get; set; } = false;

        public TransactionModel(){
            this.TransactionId = Guid.NewGuid().ToString();
            
        }
        
    }
}