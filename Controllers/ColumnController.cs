using Microsoft.AspNetCore.Mvc;
using Synthesis.Model;
using Microsoft.AspNetCore.Authorization;
using Synthesis.ViewModel;
using Synthesis.Domain.DTOs;
using Synthesis.Services;

namespace Synthesis.Controllers{
    [ApiController]
    [Route("column")]
    public class ColumnController : ControllerBase {
        private readonly ColumnServices _columnServices;
        public ColumnController(ColumnServices columnServices) {
            _columnServices = columnServices ?? throw new ArgumentNullException(nameof(columnServices));
        }

        [HttpPost]
        public IActionResult Add(ColumnViewModel columnView){
            try{
                Column newColumn = _columnServices.CreateColumn(columnView.WorkspaceId, columnView.Title, columnView.Index);
                return Ok(newColumn);
            } catch (ArgumentException ex){
                return BadRequest(ex.Message);
            }
        }

        //[Authorize]
        [HttpGet]
        public IActionResult Get(){
            List<ColumnDTO> columnList = _columnServices.Get();
            return Ok(columnList);
        }

        //[Authorize]
        [HttpPut]
        public IActionResult Update(string id, ColumnViewModel columnView){
            try{
                Column column = _columnServices.UpdateColumn(id, columnView.WorkspaceId, columnView.Title, columnView.Index);
                return Ok(column);
            } catch (ArgumentException ex){
                return BadRequest(ex.Message);
            }
        }
        //[Authorize]
        [HttpDelete]
        public IActionResult Delete(string id){
            try{
                Column column = _columnServices.DeleteColumn(id);
                return Ok(column);
            } catch (ArgumentException ex){
                return BadRequest(ex.Message);
            }
        }
    }
}