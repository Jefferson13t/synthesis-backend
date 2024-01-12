using Synthesis.Model;
using BCrypt.Net;
using static BCrypt.Net.BCrypt;

namespace Synthesis.Services

{
    public class UserServices : IUserServices {
        private readonly IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository){
            _userRepository = userRepository;
        }
        public User CreateUser(string Name, string Email, string Password){

            User userFound = _userRepository.Get(Email);

            if(userFound != null){
                throw new ArgumentException("Email já cadastrado.");
            }

            int workFactor = 12;
            var hashedPassword = HashPassword(Password, workFactor);
            
            User newUser = new User(Name, Email, hashedPassword);
            _userRepository.Add(newUser);
            return newUser;
        } 

    }
}