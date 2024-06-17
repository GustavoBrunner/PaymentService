using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using user_api.Entities.Enums;

namespace payment_system.Entities
{
    public class User 
    {
        [Key]
        public string UserId { get; set; } = string.Empty;
        
        public string Name { get; set; } = string.Empty;
        
        [Precision(12,2)]
        public decimal Money { get; set; } = 0;

        public UserType Type { get; set; }

    }
}