using System;

namespace ProjectFatec.WebApi.Models.Request
{
    public class UserUpdateRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string CPF { get; set; }
    }
}


