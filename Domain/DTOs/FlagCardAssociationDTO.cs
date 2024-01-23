using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Synthesis.Model;

namespace Synthesis.Domain.DTOs
{
    public class FlagCardAssociationDTO{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string CardId { get; set; }
        public string FlagId { get; set; }
        public FlagCardAssociationDTO(string Id, string CardId, string FlagId){
            this.Id = Id;
            this.CardId = CardId;
            this.FlagId = FlagId;
        }
    }
}