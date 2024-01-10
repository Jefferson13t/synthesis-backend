using Microsoft.AspNetCore.Mvc;
using Synthesis.Model;
using Synthesis.ViewModel;
using Synthesis.Services;

namespace Synthesis.Controllers{
    [ApiController]
    [Route("api/v1/user")]
    public class UserController : ControllerBase {
        private readonly UserServices _userServices;
        public UserController(UserServices userServices) {
            _userServices = userServices;
        }
        [HttpPost]
        public IActionResult Add(UserViewModel userView){
            User newUser = _userServices.CreateUser(userView.Name, userView.Email, userView.Password);
            return Ok(newUser);
        }
    }
}