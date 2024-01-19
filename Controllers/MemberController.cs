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

        //[Authorize]
        [HttpPut]
        public IActionResult Update(string id, MemberViewModel memberView){
            try{
                Member member = _memberServices.UpdateMember(id, memberView.UserId, memberView.WorkspaceId, memberView.Role);
                return Ok(member);
            } catch (ArgumentException ex){
                return BadRequest(ex.Message);
            }
        }
        
        //[Authorize]
        [HttpDelete]
        public IActionResult Delete(string id){
            try{
                Member member = _memberServices.DeleteMember(id);
                return Ok(member);
            } catch (ArgumentException ex){
                return BadRequest(ex.Message);
            }
        }
    }
}