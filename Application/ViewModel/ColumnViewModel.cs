using Microsoft.AspNetCore.Http;

namespace Synthesis.ViewModel
{
    public class ColumnViewModel{
        public string WorkspaceId { get; set; }
        public string Title { get; set; }
        public int Index { get; set; }

        public ColumnViewModel(string WorkspaceId, string Title, int Index){
            this.WorkspaceId = WorkspaceId;
            this.Title = Title;
            this.Index = Index;
        }
    }
}