using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WFM.Data;
using WFM.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WFM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetUsers()
        {
            var appUsers =  await _context.ApplicationUser.ToListAsync();
            List<UserModel> usersList = new List<UserModel>();
            foreach (var user in appUsers)
            {
                usersList.Add(new UserModel() { Id = user.Id, UserName = user.UserName, Role = user.Role, Password = user.Password });
            }
            return usersList;
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> Get(int id)
        {
            var user = await _context.ApplicationUser.FindAsync(id);
            return new UserModel() { UserName = user.UserName, Role = user.Role, Password = user.Password };
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTech(string id, UserModel user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }
            var appUser = await _context.ApplicationUser.FindAsync(id);
            if (!string.IsNullOrEmpty(user.Password))
            {
                appUser.Password = user.Password;
            }
            if (!string.IsNullOrEmpty(user.Role))
            {
                appUser.Role = user.Role;
            }
            if (!string.IsNullOrEmpty(user.UserName))
            {
                appUser.UserName = user.UserName;
            }
            _context.Entry(appUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(new Response { Status = "Success", Message = "User updated successfully!" });
        }
        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IdentityUser>> Delete(string id)
        {
            var users = await _context.ApplicationUser.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }

            _context.ApplicationUser.Remove(users);
            await _context.SaveChangesAsync();

            return users;
        }
        private bool UserExists(string id)
        {
            return _context.ApplicationUser.Any(e => e.Id == id);
        }
    }
}
