using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inlamning1.Data;
using Inlamning1.Entities;
using Inlamning1.Models;
using System.Text.RegularExpressions;

namespace Inlamning1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly SqlContext _context;

        public UsersController(SqlContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UpdateUser model)
        {
            var checkEmail = model.Email;
            var checkPassword = model.Password;
            var user = await _context.Users.FindAsync(id);

            Regex emailRegex = new(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match emailMatch = emailRegex.Match(checkEmail);

            Regex passwordRegex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$");
            Match passwordMatch = passwordRegex.Match(checkPassword);

            if (id != model.Id)
            {
                return BadRequest();
            }
            if (user == null)
            {
                return NotFound();
            }
            if (emailMatch.Success && passwordMatch.Success)
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;
                user.Password = model.Password;

                _context.Entry(user).State = EntityState.Modified;
            }
            else
            {
                return BadRequest();
            }
   
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

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(CreateUser model)
        {

            var checkEmail = model.Email;
            var checkPassword = model.Password;

            Regex emailRegex = new(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match emailMatch = emailRegex.Match(checkEmail);

            Regex passwordRegex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$");
            Match passwordMatch = passwordRegex.Match(checkPassword);

            if (emailMatch.Success && passwordMatch.Success)
            {
                var user = new User()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = model.Password
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetUser", new { id = user.Id }, user);
            }
            else
            {
                return BadRequest();
            }


        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
