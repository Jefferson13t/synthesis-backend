using Synthesis.Domain.DTOs;

namespace Synthesis.Model

{
    public interface IUserServices {
        User CreateUser(string Name, string Email, string Password);
        List<UserDTO> Get();
    }
}