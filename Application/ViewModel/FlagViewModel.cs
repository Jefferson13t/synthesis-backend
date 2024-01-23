using Microsoft.AspNetCore.Http;

namespace Synthesis.ViewModel
{
    public class FlagViewModel{
        public string WorkspaceId { get; set; }
        public string Title { get; set; }
        public string Color { get; set; }

        public FlagViewModel(string WorkspaceId, string Title, string Color){
            this.WorkspaceId = WorkspaceId;
            this.Title = Title;
            this.Color = Color;
        }
    }
}