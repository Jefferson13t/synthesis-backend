using Synthesis.Domain.DTOs;

namespace Synthesis.Model
{
    public interface IUserRepository{
        void Add(User user);
        List<UserDTO> Get();
        User Get(string email);
    }
}