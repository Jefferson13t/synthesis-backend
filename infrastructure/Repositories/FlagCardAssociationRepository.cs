using MongoDB.Driver;
using Synthesis.Model;
using Synthesis.Connection;
using Synthesis.Domain.DTOs;
using MongoDB.Bson;

namespace  Synthesis.Repository
{
    public class FlagCardAssociationRepository : IFlagCardAssociationRepository {
        private readonly IMongoCollection<FlagCardAssociation> _flagCardAssociationCollection;
        public FlagCardAssociationRepository(){
            IMongoDatabase database = ConnectionContext.ConnectionToMongo();
            _flagCardAssociationCollection = database.GetCollection<FlagCardAssociation>("flagCardAssociations");

        }

        public void Add(FlagCardAssociation flagCardAssociation){
            _flagCardAssociationCollection.InsertOne(flagCardAssociation);  
        }

        public List<FlagCardAssociationDTO> Get() {
            FilterDefinition<FlagCardAssociation> filter = Builders<FlagCardAssociation>.Filter.Empty;
            var projection = Builders<FlagCardAssociation>.Projection.Include("id").Include("cardId").Include("flagId");
            List<FlagCardAssociationDTO> result = _flagCardAssociationCollection.Find(filter).Project<FlagCardAssociationDTO>(projection).ToList();
            return result;
        }

        public FlagCardAssociation GetById(string flagCardAssociationId){
            FlagCardAssociation flagCardAssociationFound = _flagCardAssociationCollection.Find(x => x.Id == flagCardAssociationId).FirstOrDefault();
            if(flagCardAssociationFound == null){
                throw new ArgumentException("FlagCardAssociation não encontrado.");
            }
            return flagCardAssociationFound;
        }

        public void Update(FlagCardAssociation flagCardAssociationUpdated){

            var filter = Builders<FlagCardAssociation>.Filter.Eq(x => x.Id, flagCardAssociationUpdated.Id);
            var update = Builders<FlagCardAssociation>.Update
                .Set(x => x.CardId, flagCardAssociationUpdated.CardId)
                .Set(x => x.FlagId, flagCardAssociationUpdated.FlagId);

            _flagCardAssociationCollection.UpdateOne(filter, update);    
        }
        
        public void Delete(string Id){
            var filter = Builders<FlagCardAssociation>.Filter.Eq(x => x.Id, Id);
            _flagCardAssociationCollection.DeleteOneAsync(filter);    
        }
    }
}
