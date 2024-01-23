using Synthesis.Domain.DTOs;
using Synthesis.Model;

namespace Synthesis.Model

{
    public interface ICardServices {
        Card CreateCard(string ColumnId, string Title, string Description, DateTime Date, int Index);
        List<CardDTO> Get();
        Card UpdateCard(string Id, string ColumnId, string Title, string Description, DateTime Date, int Index);
        Card DeleteCard(string Id);
    }
}