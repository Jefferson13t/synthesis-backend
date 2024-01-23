using Microsoft.AspNetCore.Mvc;
using Synthesis.Model;
using Microsoft.AspNetCore.Authorization;
using Synthesis.ViewModel;
using Synthesis.Domain.DTOs;
using Synthesis.Services;

namespace Synthesis.Controllers{
    [ApiController]
    [Route("flagCardAssociation")]
    public class FlagCardAssociationController : ControllerBase {
        private readonly FlagCardAssociationServices _flagCardAssociationServices;
        public FlagCardAssociationController(FlagCardAssociationServices flagCardAssociationServices) {
            _flagCardAssociationServices = flagCardAssociationServices ?? throw new ArgumentNullException(nameof(flagCardAssociationServices));
        }

        [HttpPost]
        public IActionResult Add(FlagCardAssociationViewModel flagCardAssociationView){
            try{
                FlagCardAssociation newFlagCardAssociation = _flagCardAssociationServices.CreateFlagCardAssociation(flagCardAssociationView.CardId, flagCardAssociationView.FlagId);
                return Ok(newFlagCardAssociation);
            } catch (ArgumentException ex){
                return BadRequest(ex.Message);
            }
        }

        //[Authorize]
        [HttpGet]
        public IActionResult Get(){
            List<FlagCardAssociationDTO> flagCardAssociationList = _flagCardAssociationServices.Get();
            return Ok(flagCardAssociationList);
        }

        //[Authorize]
        [HttpPut]
        public IActionResult Update(string id, FlagCardAssociationViewModel flagCardAssociationView){
            try{
                FlagCardAssociation flagCardAssociation = _flagCardAssociationServices.UpdateFlagCardAssociation(id, flagCardAssociationView.CardId, flagCardAssociationView.FlagId);
                return Ok(flagCardAssociation);
            } catch (ArgumentException ex){
                return BadRequest(ex.Message);
            }
        }
        
        //[Authorize]
        [HttpDelete]
        public IActionResult Delete(string id){
            try{
                FlagCardAssociation flagCardAssociation = _flagCardAssociationServices.DeleteFlagCardAssociation(id);
                return Ok(flagCardAssociation);
            } catch (ArgumentException ex){
                return BadRequest(ex.Message);
            }
        }
    }
}