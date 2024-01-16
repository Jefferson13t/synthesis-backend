using Synthesis.Domain.DTOs;

namespace Synthesis.Model
{
    public interface IWorkspaceRepository{
        void Add(Workspace Workspace);
        List<WorkspaceDTO> Get();
        Workspace Get(string workspaceId);
    }
}