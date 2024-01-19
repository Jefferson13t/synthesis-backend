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
            var projection = Builders<Card>.Projection.Include("id").Include("columnId").Include("title").Include("description").Include("date").Include("index");
            List<CardDTO> result = _cardCollection.Find(filter).Project<CardDTO>(projection).ToList();
            return result;
        }

        public Card GetById(string cardId){
            Card cardFound = _cardCollection.Find(x => x.Id == cardId).FirstOrDefault();
            if(cardFound == null){
                throw new ArgumentException("Card não encontrado.");
            }
            return cardFound;
        }

        public void Update(Card cardUpdated){

            var filter = Builders<Card>.Filter.Eq(x => x.Id, cardUpdated.Id);
            var update = Builders<Card>.Update
                .Set(x => x.ColumnId, cardUpdated.ColumnId)
                .Set(x => x.Title, cardUpdated.Title)
                .Set(x => x.Description, cardUpdated.Description)
                .Set(x => x.Date, cardUpdated.Date)
                .Set(x => x.Index, cardUpdated.Index);

            _cardCollection.UpdateOne(filter, update);    
        }

        public void Delete(string Id){
            var filter = Builders<Card>.Filter.Eq(x => x.Id, Id);
            _cardCollection.DeleteOneAsync(filter);    
        }
    }
}

