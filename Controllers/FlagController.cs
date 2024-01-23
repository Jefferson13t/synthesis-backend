using Microsoft.AspNetCore.Mvc;
using Synthesis.Model;
using Microsoft.AspNetCore.Authorization;
using Synthesis.ViewModel;
using Synthesis.Domain.DTOs;
using Synthesis.Services;

namespace Synthesis.Controllers{
    [ApiController]
    [Route("flag")]
    public class FlagController : ControllerBase {
        private readonly FlagServices _flagServices;
        public FlagController(FlagServices flagServices) {
            _flagServices = flagServices ?? throw new ArgumentNullException(nameof(flagServices));
        }

        [HttpPost]
        public IActionResult Add(FlagViewModel flagView){
            try{
                Flag newFlag = _flagServices.CreateFlag(flagView.WorkspaceId, flagView.Title, flagView.Color);
                return Ok(newFlag);
            } catch (ArgumentException ex){
                return BadRequest(ex.Message);
            }
        }

        //[Authorize]
        [HttpGet]
        public IActionResult Get(){
            List<FlagDTO> flagList = _flagServices.Get();
            return Ok(flagList);
        }

        //[Authorize]
        [HttpPut]
        public IActionResult Update(string id, FlagViewModel flagView){
            try{
                Flag flag = _flagServices.UpdateFlag(id, flagView.WorkspaceId, flagView.Title, flagView.Color);
                return Ok(flag);
            } catch (ArgumentException ex){
                return BadRequest(ex.Message);
            }
        }
        //[Authorize]
        [HttpDelete]
        public IActionResult Delete(string id){
            try{
                Flag flag = _flagServices.DeleteFlag(id);
                return Ok(flag);
            } catch (ArgumentException ex){
                return BadRequest(ex.Message);
            }
        }
    }
}