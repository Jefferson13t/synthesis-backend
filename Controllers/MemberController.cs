using Microsoft.AspNetCore.Mvc;
using Synthesis.Model;
using Microsoft.AspNetCore.Authorization;
using Synthesis.ViewModel;
using Synthesis.Domain.DTOs;
using Synthesis.Services;

namespace Synthesis.Controllers{
    [ApiController]
    [Route("member")]
    public class MemberController : ControllerBase {
        private readonly MemberServices _memberServices;
        public MemberController(MemberServices memberServices) {
            _memberServices = memberServices ?? throw new ArgumentNullException(nameof(memberServices));
        }

        [HttpPost]
        public IActionResult Add(MemberViewModel memberView){
            try{
                Member newMember = _memberServices.CreateMember(memberView.UserId, memberView.WorkspaceId, memberView.Role);
                return Ok(newMember);
            } catch (ArgumentException ex){
                return BadRequest(ex.Message);
            }
        }

        //[Authorize]
        [HttpGet]
        public IActionResult Get(){
            List<MemberDTO> memberList = _memberServices.Get();
            return Ok(memberList);
        }
    }
}