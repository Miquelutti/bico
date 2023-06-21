using System.ComponentModel.DataAnnotations;

namespace Bico.WebApi.Models.Request
{
    public class AuthenticateRequestRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}