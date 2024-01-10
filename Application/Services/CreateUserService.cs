using Synthesis.Model;

namespace Synthesis.Services

{
    public class UserServices : IUserServices {
        private readonly IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository){
            _userRepository = userRepository;
        }
        public User CreateUser(string Name, string Email, string Password){

            User newUser = new User(Name, Email, Password);
            _userRepository.Add(newUser);
            return newUser;
        } 
    }
}