using System;

namespace Fatec.Domain.Entities
{
    public class RegistroEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
