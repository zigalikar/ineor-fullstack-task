using System.ComponentModel.DataAnnotations;

namespace IneorTaskBackend.Model.Login
{
    public class LoginRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }

    public class LoginResponse
    {
        public string AccessToken { get; set; }
    }
}
