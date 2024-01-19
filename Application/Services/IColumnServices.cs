using Synthesis.Domain.DTOs;

namespace Synthesis.Model

{
    public interface IColumnServices {
        Column CreateColumn(string WorkspaceID, string Title, int Index);
        List<ColumnDTO> Get();
    }
}