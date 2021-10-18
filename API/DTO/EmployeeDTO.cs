namespace API.DTO
{
    public class EmployeeDTO
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email {get; set;}

        public string EmailPrefered {get; set;}

        public string PhoneNumber { get; set; }

        public string PhoneNumberPrefered {get; set;}

        public string Supervisor { get; set; }
    }
}