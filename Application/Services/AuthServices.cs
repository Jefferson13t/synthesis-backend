using Synthesis.Model;
using BCrypt.Net;
using static BCrypt.Net.BCrypt;

namespace Synthesis.Services

{
    public class AuthServices : IAuthServices {
        private readonly IUserRepository _userRepository;
        public AuthServices(IUserRepository userRepository){
            _userRepository = userRepository;
        }
        public object Login(string Email, string Password){

            try{
                User userFound = _userRepository.Get(Email);
                bool passwordsMatch = Verify(Password, userFound.Password);
                if(!passwordsMatch){
                    throw new ArgumentException("Senha incorreta");
                }
                var token = TokenService.GenerateToken(userFound);
                return token;

            } catch(ArgumentException){
                throw;
            }
        }
    }
}