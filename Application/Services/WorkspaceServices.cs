using Synthesis.Model;
using Synthesis.Domain.DTOs;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Synthesis.Services

{
    public class WorkspaceServices : IWorkspaceServices {
        private readonly IWorkspaceRepository _workspaceRepository;
        private readonly MemberServices _memberServices;
        private readonly IUserRepository _userRepository;

        public WorkspaceServices(IWorkspaceRepository workspaceRepository, MemberServices memberServices, IUserRepository userRepository){
            _workspaceRepository = workspaceRepository ?? throw new ArgumentNullException(nameof(workspaceRepository));
            _memberServices = memberServices ?? throw new ArgumentNullException(nameof(memberServices));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));

        }

        public Workspace CreateWorkspace(string Name, string UserId){

            if(!ObjectId.TryParse(UserId, out _)){
                throw new ArgumentException("Id não é válido.");
            }

            User userFound = _userRepository.GetById(UserId);
            
            if(userFound == null){
                throw new ArgumentException("Usuario não encontrado.");
            }


            Workspace newWorkspace = new Workspace(Name);
            _workspaceRepository.Add(newWorkspace);
            _memberServices.CreateMember(UserId, newWorkspace.Id, Role.Admin);

            return newWorkspace;
        } 

        public List<WorkspaceDTO> Get(){
            return _workspaceRepository.Get();
        }

        public Workspace UpdateWorkspace(string Id, string Name) {

            Workspace workspaceFound = _workspaceRepository.GetById(Id);
            if(workspaceFound == null){
                throw new ArgumentException("Workspace não encontrado.");
            }

            workspaceFound.Name = Name;

            _workspaceRepository.Update(workspaceFound);
            return workspaceFound;
        }
        
        public Workspace DeleteWorkspace(string Id) {

            Workspace workspaceFound = _workspaceRepository.GetById(Id);
            if(workspaceFound == null){
                throw new ArgumentException("Workspace não encontrado.");
            }
            _workspaceRepository.Delete(Id);
            return workspaceFound;
        }
    }
}

