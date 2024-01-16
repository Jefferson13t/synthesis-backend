using Microsoft.AspNetCore.Mvc;
using Synthesis.Model;
using Microsoft.AspNetCore.Authorization;
using Synthesis.ViewModel;
using Synthesis.Domain.DTOs;
using Synthesis.Services;

namespace Synthesis.Controllers{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase {
        private readonly UserServices _userServices;
        public UserController(UserServices userServices) {
            _userServices = userServices;
        }

        [HttpPost]
        public IActionResult Add(UserViewModel userView){
            try{
                User newUser = _userServices.CreateUser(userView.Name, userView.Email, userView.Password);
                return Ok(newUser);
            } catch (ArgumentException ex){
                return BadRequest(ex.Message);
            }
        }

        //[Authorize]
        [HttpGet]
        public IActionResult Get(){
            List<UserDTO> userList = _userServices.Get();
            return Ok(userList);
        }
    }
}