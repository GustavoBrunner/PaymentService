using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using payment_system.Entities;
using user_api.Repositories;
using user_api.ViewModels;

namespace user_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private const string apiUrl = "transaction";
        private readonly IUserRepository _userRepository;

        private readonly JsonSerializerOptions _serializerOptions;
        private readonly IHttpClientFactory _clientFactory;

        private Transaction transaction1;

        public UserController(IUserRepository userRepository, IHttpClientFactory clientFactory)
        {
            _userRepository = userRepository;
            this._clientFactory = clientFactory;
            _serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true};
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserByIdAsync(string id){
            try{
                if(string.IsNullOrEmpty(id)){
                    return NotFound("User not informed!");
                }
                var user = await _userRepository.FindByIdAsync(id);
                if(user == null){
                    return NotFound("User not found!");
                }
                return Ok(user);
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<User>> CreateNewUserAsync(User user){
            ModelState.Remove(nameof(user.UserId));
            try{
                if(!ModelState.IsValid){
                    return BadRequest("Invalid data!");
                }
                var userCreated = await _userRepository.CreateUserAsync(user);
                if(userCreated == null){
                    return BadRequest("Not possible to create user");
                }
                return Ok(userCreated);
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult> UpdateUserAsync(User user){
            try{
                if(!ModelState.IsValid){
                    return BadRequest("Invalid data!");
                }
                if(!_userRepository.CheckIfUserExists(user.UserId)){
                    return BadRequest("User does not exist!");
                }
                await _userRepository.UpdateUserAsync(user);
                if(!await _userRepository.SaveChangesAsync()){
                    return Ok(user);
                }
                return Ok(user);
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<ActionResult> DeleUser(string id){
            try{
                if(string.IsNullOrEmpty(id)){
                    return NotFound("User not informed!");
                }
                if(!_userRepository.CheckIfUserExists(id)){
                    return NotFound("User does not exist");
                }
                await _userRepository.DeleteUser(id);
                if(!await _userRepository.SaveChangesAsync()){
                    return BadRequest("Was not possible to delete user!");
                }
                return Ok("User deleted!");
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("/transaction")]
        public async Task<ActionResult<Transaction>> CreateNewTransaction(TransactionViewModel transaction){
            var client = _clientFactory.CreateClient("payment-system");

            StringContent content = new StringContent(
                JsonSerializer.Serialize(transaction), Encoding.UTF8, "application/json");
            
            using(var response = await client.PostAsync(apiUrl, content)){
                if(response.IsSuccessStatusCode){
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    var transaction1 = JsonSerializer.Deserialize<TransactionViewModel>(apiResponse, _serializerOptions); 
                }
            }
            
            return transaction1;
        }
    }
}