using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmacyJWTApi.Models;

namespace PharmacyJWTApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserDetailsController : ControllerBase
    {
        private readonly PharmacyDbContext _context;

        public UserDetailsController(PharmacyDbContext context)
        {
            _context = context;
        }

        // GET: api/UserDetails
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<UserDetail>>> GetUserDetails()
        {
            return await _context.UserDetails.ToListAsync();
        }
        [HttpGet]
        [Route("CurrentProfile")]
        public async Task<ActionResult<UserDetail>> CurrentProfile()
        {
            int id = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var userDetail = await _context.UserDetails.FindAsync(id);

            if (userDetail == null)
            {
                return NotFound();
            }

            return userDetail;
        }
        // GET: api/UserDetails/5
        [HttpGet("{id}")]

        public async Task<ActionResult<UserDetail>> GetUserDetail(int id)
        {
           
            var userDetail = await _context.UserDetails.FindAsync(id);

            if (userDetail == null)
            {
                return NotFound();
            }

             return userDetail;
        }

        // PUT: api/UserDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserDetail(int id, UserDetail userDetail)
        {
            if (id != userDetail.User_id)
            {
                return BadRequest();
            }

            _context.Entry(userDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserDetailExists(id))
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

        // POST: api/UserDetails
        
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<UserDetail>> PostUserDetail(UserDetail userDetail)
        {
            _context.UserDetails.Add(userDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserDetail", new { id = userDetail.User_id }, userDetail);
        }

        // DELETE: api/UserDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserDetail(int id)
        {
            var userDetail = await _context.UserDetails.FindAsync(id);
            if (userDetail == null)
            {
                return NotFound();
            }

            _context.UserDetails.Remove(userDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserDetailExists(int id)
        {
            return _context.UserDetails.Any(e => e.User_id == id);
        }
    }
}
