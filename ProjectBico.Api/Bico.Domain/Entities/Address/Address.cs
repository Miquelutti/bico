using UserEntity = Fatec.Domain.Entities.User.User;

namespace Fatec.Domain.Entities.Address
{
    public class Address : Entity
    {
        public string CEP { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Complement { get; set; }
        public string Reference { get; set; }
        public UserEntity User { get; set; }
        public virtual long UserId { get; set; }

        public void Update(Address address)
        {
            this.CEP = address.CEP;
            this.Street = address.Street;
            this.Number = address.Number;
            this.Neighborhood = address.Neighborhood;
            this.City = address.City;
            this.State = address.State;
            this.Reference = address.Reference;
        }

        public void UpdateCEP(Address address) => this.CEP = address.CEP;
    }
}
