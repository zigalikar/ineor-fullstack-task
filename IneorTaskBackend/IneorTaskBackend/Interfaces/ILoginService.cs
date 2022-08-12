using System.Threading.Tasks;
using IneorTaskBackend.Model.Login;

namespace IneorTaskBackend.Interfaces
{
    public interface ILoginService
    {
        Task<LoginResponse> LoginAsync(LoginRequest loginRequest);
        Task SignupAsync(LoginRequest signupRequest);
    }
}
