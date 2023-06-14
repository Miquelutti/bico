using System;
using System.Collections.Generic;
using AddressEntity = Fatec.Domain.Entities.Address.Address;
using RequestEntity = Fatec.Domain.Entities.Request.Request;
using ContractEntity = Fatec.Domain.Entities.Contract.Contract;

namespace Fatec.Domain.Entities.User
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public string CPF { get; set; }
        public AddressEntity Address { get; set; }
        public ICollection<RequestEntity> Requests { get; set; }
        public ICollection<ContractEntity> Contracts { get; set; }

        public void Update(User user) 
        {
            this.Name = user.Name;
            this.Email = user.Email;
            this.BirthDate = user.BirthDate;
            this.CPF = user.CPF;
        }
    }
}
