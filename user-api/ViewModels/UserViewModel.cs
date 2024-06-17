using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using user_api.Entities.Enums;

namespace user_api.ViewModels
{
    public class UserViewModel
    {
        public string UserId { get; set; } = string.Empty;
        
        public string Name { get; set; } = string.Empty;
        
        [Precision(12,2)]
        public decimal Money { get; set; } = 0;

        public UserType Type { get; set; }
    }
}