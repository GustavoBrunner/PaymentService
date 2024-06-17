using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace user_api.Controllers
{
    [ApiController]
    [Route("api/transaction")]
    public class UserTransactionController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions(){
            return null;
        }
        
    }
}