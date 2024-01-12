using Synthesis.Model;

namespace Synthesis.Model

{
    public interface IAuthServices {
        object Login(string Email, string Password);
    }
}