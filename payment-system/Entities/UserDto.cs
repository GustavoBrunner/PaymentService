using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using payment_system.Entities.Enums;

namespace payment_system.Entities
{
    public class UserDto 
    {
        public string UserId { get; set; } = string.Empty;
        
        public string Name { get; set; } = string.Empty;

        public decimal Money { get; set; } = 0;

        public UserType Type { get; set; }

    }
}