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
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public User CreateUser(string Name, string Email, string Password){

            User userFound = _userRepository.GetByEmail(Email);

            if(userFound != null){
                throw new ArgumentException("Email já cadastrado.");
            }

            var hashedPassword = SecurityServices.GenerateHash(Password);
            
            User newUser = new User(Name, Email, hashedPassword);

            _userRepository.Add(newUser);
            return newUser;
        } 

        public List<UserDTO> Get(){
            return _userRepository.Get();
        }

        public User UpdateUser(string Id, string Name, string Email, string Password) {

            User userFound = _userRepository.GetById(Id);
            if(userFound == null){
                throw new ArgumentException("Usuario não encontrado.");
            }

            var hashedPassword = SecurityServices.GenerateHash(Password);

            userFound.Name = Name;
            userFound.Email = Email;
            userFound.Password = hashedPassword;

            _userRepository.Update(userFound);
            return userFound;
        }
        
        public User DeleteUser(string Id) {

            User userFound = _userRepository.GetById(Id);
            if(userFound == null){
                throw new ArgumentException("Usuario não encontrado.");
            }
            _userRepository.Delete(Id);
            return userFound;
        }
    }
}