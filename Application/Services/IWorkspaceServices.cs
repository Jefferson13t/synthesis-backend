using Synthesis.Domain.DTOs;

namespace Synthesis.Model

{
    public interface IWorkspaceServices {
        Workspace CreateWorkspace(string Name, string UserId);
        List<WorkspaceDTO> Get();
    }
}