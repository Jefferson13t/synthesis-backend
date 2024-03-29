using Microsoft.AspNetCore.Http;

namespace Synthesis.ViewModel
{
    public class UserViewModel{
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserViewModel(string Name, string Email, string Password){
            this.Name = Name;
            this.Email = Email;
            this.Password = Password;
        }
    }
}