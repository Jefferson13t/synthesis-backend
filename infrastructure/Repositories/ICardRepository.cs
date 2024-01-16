using Synthesis.Domain.DTOs;

namespace Synthesis.Model
{
    public interface ICardRepository{
        void Add(Card user);
        List<CardDTO> Get();
    }
}