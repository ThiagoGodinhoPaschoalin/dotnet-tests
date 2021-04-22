using SharedDomain.Models.Enums;
using System.Collections.Generic;

namespace LibApiSampleAbstraction.Businesses.AccountDtos
{
    public class CreateNewRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderType Gender { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> ProfileNames { get; set; }
    }
}