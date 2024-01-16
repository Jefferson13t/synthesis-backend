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
            _workspaceRepository = workspaceRepository;
            _memberServices = memberServices;
            _userRepository = userRepository;
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
    }
}

