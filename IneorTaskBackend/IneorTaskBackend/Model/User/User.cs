using System.ComponentModel.DataAnnotations.Schema;

namespace IneorTaskBackend.Model.Login
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string PasswordSalt { get; set; }

        public string Role { get; set; }
    }
}
