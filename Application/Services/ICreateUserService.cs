using Synthesis.Model;

namespace Synthesis.Model

{
    public interface IUserServices {
        public User CreateUser(string Name, string Email, string Password);
    }
}