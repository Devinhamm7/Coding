using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using API.Data;
using API.DTO;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }
        
        
        [HttpGet("supervisor")]
        public IEnumerable<Supervisor> GetSupervisors()
        {
            // downloading JSON from the URL string
            var w = new WebClient();                 
            
            var json = w.DownloadString("https://o3m5qixdng.execute-api.us-east-1.amazonaws.com/api/managers");

            // deserializing the JSON to be input into the database
            var supervisors = JsonConvert.DeserializeObject<List<Supervisor>>(json);
            
            //iterate over each supervisor to correct the grammar for their name
             foreach (var supervisor in supervisors)
             {
                _context.Supervisors.Add(supervisor);
             }

             //save Deserialized JSON into the data context
              _context.SaveChangesAsync();
             
            // return a list of supervisors
            return  _context.Supervisors.ToList();
        }

        [HttpPost("submit")]
        public async Task<ActionResult<SubmitDTO>> Submit (SubmitDTO submitDto)
        {
            if (await UserExists(submitDto.Email)) return BadRequest("Email is taken");
            
            var user = new AppUser
            {
                FirstName = submitDto.FirstName,
                LastName = submitDto.LastName,
                Email = submitDto?.Email,
                EmailPrefered = Convert.ToBoolean(submitDto?.EmailPrefered),
                PhoneNumber = Convert.ToString(submitDto?.PhoneNumber),
                PhoneNumberPrefered = Convert.ToBoolean(submitDto?.PhonePrefered),
                Supervisor = submitDto.Supervisor
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new SubmitDTO
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user?.Email,
                PhoneNumber = user?.PhoneNumber.ToString(),
            };
        }
        
        private async Task<bool> UserExists(string email)
        {
            return await _context.Users.AnyAsync(user => user.Email == email);
        }
    }
}