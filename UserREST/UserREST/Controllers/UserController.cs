using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserBL;
using UserModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserREST.Controllers
{
    /// <summary>
    /// API for Users
    /// </summary>
    
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBL _userBL;
        public UserController(IUserBL userBL)
        {
            _userBL = userBL;
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<IActionResult> GetUsersAsync()
        {
            return Ok(await _userBL.GetUsersAsync());
        }

        // GET api/<UserController>/5
        [HttpGet("{Id}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetUserByIDAsync(int Id)
        {
            var user = await _userBL.GetUserByIDAsync(Id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        //GET api/<UserController>/person @gmail.com
        [HttpGet]
        [Route("/api/User/email/{userEmail}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetUserByEmail(string userEmail)
        {
            var user = await _userBL.GetUserByEmail(userEmail);
            if (user == null) return NotFound();
            return Ok(user);
        }

        // POST api/<UserController>
        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> AddUserAsync([FromBody] User user)
        {
            try
            {
                await _userBL.AddUserAsync(user);
                //Log.Logger.Information($"new User with ID {user.Id} created");
                return CreatedAtAction("AddUser", user);
            }
            catch (Exception e)
            {
                //Log.Logger.Error($"Error thrown: {e.Message}");
                return StatusCode(400);
            }
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserAsync(int Id, [FromBody] User user)
        {
            try
            {
                await _userBL.UpdateUserAsync(user);
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteUserAsync(int Id)
        {
            try
            {
                await _userBL.DeleteUserAsync(await _userBL.GetUserByIDAsync(Id));
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
