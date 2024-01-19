using Synthesis.Model;
using Microsoft.AspNetCore.Authorization;
using Synthesis.Domain.DTOs;

namespace Synthesis.Services

{
    public class CardServices : ICardServices {
        private readonly ICardRepository _cardRepository;
        private readonly IColumnRepository _columnRepository;

        public CardServices(ICardRepository cardRepository, IColumnRepository columnRepository){
            _cardRepository = cardRepository ?? throw new ArgumentNullException(nameof(cardRepository));
            _columnRepository = columnRepository ?? throw new ArgumentNullException(nameof(columnRepository));
        }
        public Card CreateCard(string ColumnId, string Title, string Description, DateTime Date, int Index){

            Column columnFound = _columnRepository.GetById(ColumnId);

            if(columnFound == null){
                throw new ArgumentException("Coluna não encontrada.");
            }

            Card newCard = new Card(ColumnId, Title, Description, Date, Index);
            _cardRepository.Add(newCard);
            return newCard;
        } 
        
        public List<CardDTO> Get(){
            return _cardRepository.Get();
        }

        public Card UpdateCard(string Id, string ColumnId, string Title, string Description, DateTime Date, int Index) {

            Card cardFound = _cardRepository.GetById(Id);
            if(cardFound == null){
                throw new ArgumentException("Card não encontrado.");
            }

            Column columnFound = _columnRepository.GetById(ColumnId);

            if(columnFound == null){
                throw new ArgumentException("Coluna não encontrada.");
            }

            cardFound.ColumnId = ColumnId;
            cardFound.Title = Title;
            cardFound.Description = Description;
            cardFound.Date = Date;
            cardFound.Index = Index;

            _cardRepository.Update(cardFound);
            return cardFound;
        }
        
        public Card DeleteCard(string Id) {

            Card cardFound = _cardRepository.GetById(Id);
            if(cardFound == null){
                throw new ArgumentException("Card não encontrado.");
            }
            _cardRepository.Delete(Id);
            return cardFound;
        }
    }
}