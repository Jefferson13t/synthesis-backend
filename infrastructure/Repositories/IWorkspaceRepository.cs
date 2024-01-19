using Synthesis.Domain.DTOs;

namespace Synthesis.Model
{
    public interface IWorkspaceRepository{
        void Add(Workspace Workspace);
        List<WorkspaceDTO> Get();
        Workspace GetById(string workspaceId);
        void Update(Workspace workspace);
        void Delete(string workspaceId);
    }
}