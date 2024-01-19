using Synthesis.Domain.DTOs;

namespace Synthesis.Model
{
    public interface IUserRepository{
        void Add(User user);
        List<UserDTO> Get();
        User GetByEmail(string Email);
        User GetById(string Id);
        void Update(User user);
        void Delete(string Id);
    }
}