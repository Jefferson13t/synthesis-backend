using Synthesis.Domain.DTOs;

namespace Synthesis.Model
{
    public interface IMemberRepository{
        void Add(Member member);
        List<MemberDTO> Get();
        Member GetById(string Id);
        void Update(Member Member);
        void Delete(string Id);
    }
}