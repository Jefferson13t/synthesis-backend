using Microsoft.AspNetCore.Http;

namespace Synthesis.ViewModel
{
    public class WorkspaceViewModel{
        public string Name { get; set; }
        public string UserId { get; set; }

        public WorkspaceViewModel(string Name, string UserId){
            this.Name = Name;
            this.UserId = UserId;
        }
    }
}