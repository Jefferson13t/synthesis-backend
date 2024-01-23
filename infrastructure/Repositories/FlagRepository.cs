using MongoDB.Driver;
using Synthesis.Model;
using Synthesis.Connection;
using Synthesis.Domain.DTOs;
using MongoDB.Bson;

namespace  Synthesis.Repository
{
    public class FlagRepository : IFlagRepository {
        private readonly IMongoCollection<Flag> _flagCollection;
        public FlagRepository(){
            IMongoDatabase database = ConnectionContext.ConnectionToMongo();
            _flagCollection = database.GetCollection<Flag>("flags");

        }
        public void Add(Flag flag){
            _flagCollection.InsertOne(flag);  
        }
        public List<FlagDTO> Get() {
            FilterDefinition<Flag> filter = Builders<Flag>.Filter.Empty;
            var projection = Builders<Flag>.Projection.Include("id").Include("workspaceId").Include("title").Include("color");
            List<FlagDTO> result = _flagCollection.Find(filter).Project<FlagDTO>(projection).ToList();
            return result;
        }
        public Flag GetById(string Id){
            
            Flag flagFound = _flagCollection.Find(x => x.Id == Id).FirstOrDefault();
            return flagFound;
        }
        public void Update(Flag flagUpdated){

            var filter = Builders<Flag>.Filter.Eq(x => x.Id, flagUpdated.Id);
            var update = Builders<Flag>.Update
                .Set(x => x.WorkspaceId, flagUpdated.WorkspaceId)
                .Set(x => x.Title, flagUpdated.Title)
                .Set(x => x.Color, flagUpdated.Color);


            _flagCollection.UpdateOne(filter, update);    
        }

        public void Delete(string Id){
            var filter = Builders<Flag>.Filter.Eq(x => x.Id, Id);
            _flagCollection.DeleteOneAsync(filter);    
        }
    }
}