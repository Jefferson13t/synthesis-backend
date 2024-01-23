using Synthesis.Domain.DTOs;
using Synthesis.Model;

namespace Synthesis.Model

{
    public interface IMemberServices {
        Member CreateMember(string MemberId, string WorkspaceId, Role Role);
        List<MemberDTO> Get();
        Member UpdateMember(string Id, string UserId, string WorkspaceId, Role Role);
        Member DeleteMember(string Id);
    }
}