using Synthesis.Domain.DTOs;

namespace Synthesis.Model
{
    public interface IFlagCardAssociationRepository{
        void Add(FlagCardAssociation flagCardAssociation);
        List<FlagCardAssociationDTO> Get();
        FlagCardAssociation GetById(string Id);
        void Update(FlagCardAssociation FlagCardAssociation);
        void Delete(string Id);
    }
}