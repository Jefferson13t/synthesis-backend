using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Synthesis.Model;

namespace Synthesis.Model 
{
    public class Member{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string UserId { get; set; }
        public string WorkspaceId { get; set; }
        public Role Role { get; set; }

        public Member(string UserId, string WorkspaceId, Role Role){
            this.UserId = UserId;
            this.WorkspaceId = WorkspaceId;
            this.Role = Role;
        }
    }
}
