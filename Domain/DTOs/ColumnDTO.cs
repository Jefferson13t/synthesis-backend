using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Synthesis.Domain.DTOs
{
    public class ColumnDTO{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string WorkspaceId { get; set; }
        public string Title { get; set; }
        public int Index { get; set; }

        public ColumnDTO(string Id, string WorkspaceId, string Title, int Index){
            this.Id = Id;
            this.WorkspaceId = WorkspaceId;
            this.Title = Title;
            this.Index = Index;
        }
    }
}