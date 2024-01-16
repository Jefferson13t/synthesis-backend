using Synthesis.Domain.DTOs;
using Synthesis.Model;

namespace Synthesis.Model

{
    public interface IMemberServices {
        Member CreateMember(string MemberId, string WorkspaceId, Role Role);
        List<MemberDTO> Get();
    }
}