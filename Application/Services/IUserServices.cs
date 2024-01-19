using Synthesis.Domain.DTOs;

namespace Synthesis.Model

{
    public interface IUserServices {
        User CreateUser(string Name, string Email, string Password);
        List<UserDTO> Get();
        User UpdateUser(string Id, string Name, string Email, string Password);
        User DeleteUser(string Id);
    }
}