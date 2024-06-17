using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using payment_system.Entities;

namespace user_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserByIdAsync(string id){
            return null;
        }
        [HttpPost]
        public async Task<ActionResult<User>> CreateNewUserAsync(User user){
            return null;
        }
        [HttpPut]
        public async Task<ActionResult> UpdateUserAsync(User user){
            return null;
        }
        [HttpDelete]
        public async Task<ActionResult> DeleUser(string id){
            return null;
        }
    }
}