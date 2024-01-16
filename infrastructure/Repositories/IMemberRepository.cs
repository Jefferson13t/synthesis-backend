using Synthesis.Domain.DTOs;

namespace Synthesis.Model
{
    public interface IMemberRepository{
        void Add(Member member);
        List<MemberDTO> Get();
    }
}