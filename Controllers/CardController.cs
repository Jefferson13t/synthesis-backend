using Microsoft.AspNetCore.Mvc;
using Synthesis.Model;
using Microsoft.AspNetCore.Authorization;
using Synthesis.ViewModel;
using Synthesis.Domain.DTOs;
using Synthesis.Services;

namespace Synthesis.Controllers{
    [ApiController]
    [Route("card")]
    public class CardController : ControllerBase {
        private readonly CardServices _cardServices;
        public CardController(CardServices CardServices) {
            _cardServices = CardServices ?? throw new ArgumentNullException(nameof(CardServices));
        }

        [HttpPost]
        public IActionResult Add(CardViewModel cardView){
            try{
                Card newCard = _cardServices.CreateCard(cardView.ColumnId, cardView.Title, cardView.Description, cardView.Date, cardView.Index);
                return Ok(newCard);
            } catch (ArgumentException ex){
                return BadRequest(ex.Message);
            }
        }

        //[Authorize]
        [HttpGet]
        public IActionResult Get(){
            List<CardDTO> cardList = _cardServices.Get();
            return Ok(cardList);
        }

        //[Authorize]
        [HttpPut]
        public IActionResult Update(string id, CardViewModel cardView){
            Card card = _cardServices.UpdateCard(id, cardView.ColumnId, cardView.Title, cardView.Description, cardView.Date, cardView.Index);
            return Ok(card);
        }
        //[Authorize]
        [HttpDelete]
        public IActionResult Delete(string id){
            Card card = _cardServices.DeleteCard(id);
            return Ok(card);
        }
    }
}