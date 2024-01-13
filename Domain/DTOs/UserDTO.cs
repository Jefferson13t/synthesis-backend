using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Synthesis.Domain.DTOs
{
    public class UserDTO{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set;}
        public string Email { get; set;}
        public UserDTO(string Id, string Name, string Email){
            this.Id = Id;
            this.Name = Name;
            this.Email = Email;
        }
    }
}