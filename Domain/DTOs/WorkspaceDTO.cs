using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Synthesis.Domain.DTOs
{
    public class WorkspaceDTO{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set;}
        public WorkspaceDTO(string Id, string Name){
            this.Id = Id;
            this.Name = Name;
        }
    }
}