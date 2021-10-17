using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace API.Entities
{
    public class Supervisor
    {
        public string Id { get; set; }

        public string PhoneNumber { get; set; }

        public string Jurisdiction { get; set; }

        public string IdentificationNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}