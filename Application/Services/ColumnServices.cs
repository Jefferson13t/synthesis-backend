using Synthesis.Model;
using Microsoft.AspNetCore.Authorization;
using Synthesis.Domain.DTOs;

namespace Synthesis.Services

{
    public class ColumnServices : IColumnServices {
        private readonly IColumnRepository _columnRepository;
        private readonly IWorkspaceRepository _workspaceRepository;
        public ColumnServices(IColumnRepository columnRepository, IWorkspaceRepository workspaceRepository){
            _columnRepository = columnRepository ?? throw new ArgumentNullException(nameof(columnRepository));
            _workspaceRepository = workspaceRepository ?? throw new ArgumentNullException(nameof(workspaceRepository));

        }
        public Column CreateColumn(string WorkspaceId, string Title, int Index){

            Workspace WorkspaceFound = _workspaceRepository.Get(WorkspaceId);

            if(WorkspaceFound == null){
                throw new ArgumentException("Workspace não encontrado.");
            }
            
            Column newColumn = new Column(WorkspaceId, Title, Index);
            _columnRepository.Add(newColumn);
            return newColumn;
        } 
        public List<ColumnDTO> Get(){
            return _columnRepository.Get();
        }
    }
}