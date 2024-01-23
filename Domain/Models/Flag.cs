using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Synthesis.Model 
{
    public class Flag {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string WorkspaceId { get; set; }
        public string Title { get; set; }
        public string Color { get; set; }

        public Flag(string WorkspaceId, string Title, string Color){
            this.WorkspaceId = WorkspaceId;
            this.Title = Title;
            this.Color = Color;
        }
    }
}
