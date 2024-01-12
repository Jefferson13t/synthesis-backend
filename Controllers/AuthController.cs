using Microsoft.AspNetCore.Mvc;
using Synthesis.Services;
using Synthesis.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Synthesis.Model;

namespace Synthesis.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : Controller{

        private readonly IAuthServices _AuthServices;
        public AuthController(IAuthServices authServices) {
            _AuthServices = authServices;
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel LoginView){
            try{
                object token = _AuthServices.Login(LoginView.Email, LoginView.Password);
                return Ok(token);
            } catch(ArgumentException ex){
                return BadRequest(ex.Message);
            }
        }    
    }
}