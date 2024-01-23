using Synthesis.Model;
using Microsoft.AspNetCore.Authorization;
using Synthesis.Domain.DTOs;

namespace Synthesis.Services

{
    public class FlagServices : IFlagServices {
        private readonly IFlagRepository _flagRepository;
        private readonly IWorkspaceRepository _workspaceRepository;
        public FlagServices(IFlagRepository flagRepository, IWorkspaceRepository workspaceRepository){
            _flagRepository = flagRepository ?? throw new ArgumentNullException(nameof(flagRepository));
            _workspaceRepository = workspaceRepository ?? throw new ArgumentNullException(nameof(workspaceRepository));

        }
        public Flag CreateFlag(string WorkspaceId, string Title, string Color){

            Workspace workspaceFound = _workspaceRepository.GetById(WorkspaceId);

            if(workspaceFound == null){
                throw new ArgumentException("Workspace não encontrado.");
            }
            
            Flag newFlag = new Flag(WorkspaceId, Title, Color);
            _flagRepository.Add(newFlag);
            return newFlag;
        } 
        public List<FlagDTO> Get(){
            return _flagRepository.Get();
        }

        public Flag UpdateFlag(string Id, string WorkspaceId, string Title, string Color) {

            Flag flagFound = _flagRepository.GetById(Id);
            if(flagFound == null){
                throw new ArgumentException("Flag não encontrada.");
            }

            Workspace workspaceFound = _workspaceRepository.GetById(WorkspaceId);
            if(workspaceFound == null){
                throw new ArgumentException("Workspace não encontrado.");
            }

            flagFound.WorkspaceId = WorkspaceId;
            flagFound.Title = Title;
            flagFound.Color = Color;

            _flagRepository.Update(flagFound);
            return flagFound;
        }
        
        public Flag DeleteFlag(string Id) {

            Flag flagFound = _flagRepository.GetById(Id);
            if(flagFound == null){
                throw new ArgumentException("Flag não encontrada.");
            }
            _flagRepository.Delete(Id);
            return flagFound;
        }
    }
}