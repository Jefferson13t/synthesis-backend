using Microsoft.AspNetCore.Http;
using Synthesis.Model; 

namespace Synthesis.ViewModel
{
    public class MemberViewModel{
        public string UserId { get; set; }
        public string WorkspaceId { get; set; }
        public Role Role { get; set; }
        public MemberViewModel(string UserId, string WorkspaceId, Role Role){
            this.UserId = UserId;
            this.WorkspaceId = WorkspaceId;
            this.Role = Role;
        }
    }
}