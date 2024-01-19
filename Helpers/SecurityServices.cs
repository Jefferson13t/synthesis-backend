using BCrypt.Net;
using static BCrypt.Net.BCrypt;

namespace Synthesis.Services

{
    public class SecurityServices {

        public static string GenerateHash(string Password){
            int workFactor = 12;
            var hashedPassword = HashPassword(Password, workFactor);
            return hashedPassword;
        } 
    }
}