using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace API.Entities
{
    public class AppUser
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public string Email {get; set;}

        public bool EmailPrefered {get; set;}

        public string PhoneNumber { get; set; }

        public bool PhoneNumberPrefered {get; set;}

        public string Supervisor { get; set; }
    }
}