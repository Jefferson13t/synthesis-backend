using Synthesis.Model;
using BCrypt.Net;
using static BCrypt.Net.BCrypt;
using Microsoft.AspNetCore.Authorization;
using Synthesis.Domain.DTOs;

namespace Synthesis.Services

{
    public class UserServices : IUserServices {
        private readonly IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository){
            _userRepository = userRepository;
        }
        public User CreateUser(string Name, string Email, string Password){

            User userFound = _userRepository.GetByEmail(Email);

            if(userFound != null){
                throw new ArgumentException("Email já cadastrado.");
            }

            int workFactor = 12;
            var hashedPassword = HashPassword(Password, workFactor);
            
            User newUser = new User(Name, Email, hashedPassword);
            _userRepository.Add(newUser);
            return newUser;
        } 
        public List<UserDTO> Get(){
            return _userRepository.Get();
        }

    }
}