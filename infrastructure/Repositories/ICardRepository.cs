using Synthesis.Domain.DTOs;

namespace Synthesis.Model
{
    public interface ICardRepository{
        void Add(Card card);
        List<CardDTO> Get();
        Card GetById(string cardId);
        void Update(Card card);
        void Delete(string id);
    } 
}