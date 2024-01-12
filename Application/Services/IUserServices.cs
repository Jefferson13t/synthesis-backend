using Synthesis.Model;

namespace Synthesis.Model

{
    public interface IUserServices {
        User CreateUser(string Name, string Email, string Password);
    }
}