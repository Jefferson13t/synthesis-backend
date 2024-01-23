using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Synthesis.Domain.DTOs
{
    public class FlagDTO{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string WorkspaceId { get; set; }
        public string Title { get; set; }
        public string Color { get; set; }

        public FlagDTO(string Id, string WorkspaceId, string Title, string Color){
            this.Id = Id;
            this.WorkspaceId = WorkspaceId;
            this.Title = Title;
            this.Color = Color;
        }
    }
}