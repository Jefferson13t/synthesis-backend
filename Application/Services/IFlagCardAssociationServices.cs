using Synthesis.Domain.DTOs;
using Synthesis.Model;

namespace Synthesis.Model

{
    public interface IFlagCardAssociationServices {
        FlagCardAssociation CreateFlagCardAssociation(string CardId, string FlagId);
        List<FlagCardAssociationDTO> Get();
        FlagCardAssociation UpdateFlagCardAssociation(string Id, string CardId, string FlagId);
        FlagCardAssociation DeleteFlagCardAssociation(string Id);
    }
}