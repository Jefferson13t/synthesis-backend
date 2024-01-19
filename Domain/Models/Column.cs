using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Synthesis.Model 
{
    public class Column{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string WorkspaceId { get; set; }
        public string Title { get; set; }
        public int Index { get; set; }

        public Column(string WorkspaceId, string Title, int Index){
            this.WorkspaceId = WorkspaceId;
            this.Title = Title;
            this.Index = Index;
        }
    }
}
