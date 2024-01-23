using Synthesis.Domain.DTOs;

namespace Synthesis.Model

{
    public interface IColumnServices {
        Column CreateColumn(string WorkspaceID, string Title, int Index);
        List<ColumnDTO> Get();
        Column UpdateColumn(string Id, string WorkspaceId, string Title, int Index);
        Column DeleteColumn(string Id);
    }
}