using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Synthesis.Model;

namespace Synthesis.Domain.DTOs
{
    public class MemberDTO{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string UserId { get; set; }
        public string WorkspaceId { get; set; }
        public Role Role { get; set; }
        public MemberDTO(string Id, string UserId, string WorkspaceId, Role Role){
            this.Id = Id;
            this.UserId = UserId;
            this.WorkspaceId = WorkspaceId;
            this.Role = Role;
        }
    }
}