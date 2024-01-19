using Microsoft.AspNetCore.Mvc;
using Synthesis.Model;
using Microsoft.AspNetCore.Authorization;
using Synthesis.ViewModel;
using Synthesis.Domain.DTOs;
using Synthesis.Services;

namespace Synthesis.Controllers{
    [ApiController]
    [Route("workspace")]
    public class WorkspaceController : ControllerBase {
        private readonly WorkspaceServices _workspaceServices;
        public WorkspaceController(WorkspaceServices workspaceServices) {
            _workspaceServices = workspaceServices ?? throw new ArgumentNullException(nameof(workspaceServices));
        }

        //[Authorize]
        [HttpPost]
        public IActionResult Add(WorkspaceViewModel workspaceView){
            try{
                Workspace newWorkspace = _workspaceServices.CreateWorkspace(workspaceView.Name, workspaceView.UserId);
                return Ok(newWorkspace);
            } catch (ArgumentException ex){
                return BadRequest(ex.Message);
            }
        }

        //[Authorize]
        [HttpGet]
        public IActionResult Get(){
            List<WorkspaceDTO> workspaceList = _workspaceServices.Get();
            return Ok(workspaceList);
        }
        //[Authorize]
        [HttpPut]
        public IActionResult Update(string id, WorkspaceViewModel workspaceView){
            try{
                Workspace workspace = _workspaceServices.UpdateWorkspace(id, workspaceView.Name);
                return Ok(workspace);
            } catch (ArgumentException ex){
                return BadRequest(ex.Message);
            }
        }
        //[Authorize]
        [HttpDelete]
        public IActionResult Delete(string id){
            try{
                Workspace workspace = _workspaceServices.DeleteWorkspace(id);
                return Ok(workspace);
            } catch (ArgumentException ex){
                return BadRequest(ex.Message);
            }
        }
    }
}