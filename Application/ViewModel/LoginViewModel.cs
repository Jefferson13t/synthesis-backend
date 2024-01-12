using Microsoft.AspNetCore.Http;

namespace Synthesis.ViewModel
{
    public class LoginViewModel{
        public string Email { get; set; }
        public string Password { get; set; }

        public LoginViewModel(string Email, string Password){
            this.Email = Email;
            this.Password = Password;
        }
    }
}