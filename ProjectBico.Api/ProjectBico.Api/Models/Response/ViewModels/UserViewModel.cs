using System;

namespace ProjectFatec.WebApi.Models.Response.ViewModels
{
    public class UserViewModel
    {
        public virtual long Id {  get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string CPF { get; set; }
        public AddressViewModel Address { get; set; }
    }
}
