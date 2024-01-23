using Synthesis.Domain.DTOs;

namespace Synthesis.Model
{
    public interface IFlagRepository{
        void Add(Flag flag);
        List<FlagDTO> Get();
        Flag GetById(string Id);
        void Update(Flag Flag);
        void Delete(string Id);
    }
}