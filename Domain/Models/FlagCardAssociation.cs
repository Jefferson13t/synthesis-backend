using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Synthesis.Model;

namespace Synthesis.Model 
{
    public class FlagCardAssociation{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string CardId { get; set; }
        public string FlagId { get; set; }

        public FlagCardAssociation(string CardId, string FlagId){
            this.CardId = CardId;
            this.FlagId = FlagId;
        }
    }
}
