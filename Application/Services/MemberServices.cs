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
            _memberRepository = memberRepository ?? throw new ArgumentNullException(nameof(memberRepository));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _workspaceRepository = workspaceRepository ?? throw new ArgumentNullException(nameof(workspaceRepository));
        }

        public Member CreateMember(string UserId, string WorkspaceId, Role Role){

            User userFound = _userRepository.GetById(UserId);

            if(userFound == null){
                throw new ArgumentException("Usuario não encontrado.");
            }

            Workspace workspaceFound = _workspaceRepository.GetById(WorkspaceId);

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

        public Member UpdateMember(string Id, string UserId, string WorkspaceId, Role Role) {

            Member memberFound = _memberRepository.GetById(Id);
            if(memberFound == null){
                throw new ArgumentException("Member não encontrado.");
            }

            memberFound.UserId = UserId;
            memberFound.WorkspaceId = WorkspaceId;
            memberFound.Role = Role;

            _memberRepository.Update(memberFound);
            return memberFound;
        }
        
        public Member DeleteMember(string Id) {

            Member memberFound = _memberRepository.GetById(Id);
            if(memberFound == null){
                throw new ArgumentException("Member não encontrado.");
            }
            _memberRepository.Delete(Id);
            return memberFound;
        }

    }
}