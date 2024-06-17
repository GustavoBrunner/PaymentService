using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace bank_mock.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankController : ControllerBase
    {
        
        [HttpGet]
        public async Task< ActionResult<bool>> GetMock(){
            Random random =  new Random();
            var value = random.Next(0, 100);
            if(value % 2 == 0){
                return true;
            }
            else{
                return false;
            }
        }
    }
}