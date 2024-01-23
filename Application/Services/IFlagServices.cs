using Synthesis.Domain.DTOs;

namespace Synthesis.Model

{
    public interface IFlagServices {
        Flag CreateFlag(string WorkspaceID, string Title, string Color);
        List<FlagDTO> Get();
        Flag UpdateFlag(string Id, string WorkspaceId, string Title, string Color);
        Flag DeleteFlag(string Id);
    }
}