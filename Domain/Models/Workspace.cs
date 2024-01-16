using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Synthesis.Model 
{
    public class Workspace{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Name { get; set; }

        public Workspace(string Name){
            this.Name = Name;
        }
    }
}
