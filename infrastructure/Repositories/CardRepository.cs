using MongoDB.Driver;
using Synthesis.Model;
using Synthesis.Connection;
using Synthesis.Domain.DTOs;
using MongoDB.Bson;

namespace  Synthesis.Repository
{
    public class CardRepository : ICardRepository {
        private readonly IMongoCollection<Card> _cardCollection;
        public CardRepository(){
            IMongoDatabase database = ConnectionContext.ConnectionToMongo();
            _cardCollection = database.GetCollection<Card>("cards");

        }
        public void Add(Card card){
            _cardCollection.InsertOne(card);  
        }
        public List<CardDTO> Get() {
            FilterDefinition<Card> filter = Builders<Card>.Filter.Empty;
            var projection = Builders<Card>.Projection.Include("id").Include("name").Include("email");
            List<CardDTO> result = _cardCollection.Find(filter).Project<CardDTO>(projection).ToList();
            return result;
        }
    }
}