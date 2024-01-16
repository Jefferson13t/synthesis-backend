using Synthesis.Model;
using Microsoft.AspNetCore.Authorization;
using Synthesis.Domain.DTOs;

namespace Synthesis.Services

{
    public class MemberServices : IMemberServices {
        private readonly IMemberRepository _memberRepository;
        private readonly IUserRepository _userRepository;
        private readonly IWorkspaceRepository _workspaceRepository;

        public MemberServices(IMemberRepository memberRepository, IUserRepository userRepository, IWorkspaceRepository workspaceRepository){
            _memberRepository = memberRepository;
            _userRepository = userRepository;
            _workspaceRepository = workspaceRepository;

        }
        public Member CreateMember(string UserId, string WorkspaceId, Role Role){

            User userFound = _userRepository.GetById(UserId);

            if(userFound == null){
                throw new ArgumentException("Usuario não encontrado.");
            }

            Workspace workspaceFound = _workspaceRepository.Get(WorkspaceId);

            if(workspaceFound == null){
                throw new ArgumentException("Workspace não encontrado");
            }

            Member newMember = new Member(UserId, WorkspaceId, Role);
            _memberRepository.Add(newMember);
            return newMember;
        } 
        public List<MemberDTO> Get(){
            return _memberRepository.Get();
        }

    }
}