using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Synthesis.Domain.DTOs
{
    public class CardDTO{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string ColumnId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int Index { get; set; }
        
        public CardDTO(string ColumnId, string Title, string Description, DateTime Date, int Index){
            this.ColumnId = ColumnId;
            this.Title = Title;
            this.Description = Description;
            this.Date = Date;
            this.Index = Index;
        }
    }
}