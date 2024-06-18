using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using payment_system.Entities;
using payment_system.Entities.Enums;

namespace payment_system.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        //business rule: a merchant can not send money to a client.

        [HttpPost("create")]
        public async Task<ActionResult<TransactionModel>> CreateNewTransaction(TransactionModel transaction){
            
            try{
                if(!ModelState.IsValid){
                    return null;
                }
                if(transaction.Payer.Type == UserType.merchant && transaction.Receiver.Type == UserType.client){
                    return BadRequest();
                }
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}