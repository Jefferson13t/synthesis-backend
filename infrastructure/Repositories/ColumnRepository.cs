using MongoDB.Driver;
using Synthesis.Model;
using Synthesis.Connection;
using Synthesis.Domain.DTOs;
using MongoDB.Bson;

namespace  Synthesis.Repository
{
    public class ColumnRepository : IColumnRepository {
        private readonly IMongoCollection<Column> _columnCollection;
        public ColumnRepository(){
            IMongoDatabase database = ConnectionContext.ConnectionToMongo();
            _columnCollection = database.GetCollection<Column>("columns");

        }
        public void Add(Column column){
            _columnCollection.InsertOne(column);  
        }
        public List<ColumnDTO> Get() {
            FilterDefinition<Column> filter = Builders<Column>.Filter.Empty;
            var projection = Builders<Column>.Projection.Include("id").Include("workspaceId").Include("title").Include("index");
            List<ColumnDTO> result = _columnCollection.Find(filter).Project<ColumnDTO>(projection).ToList();
            return result;
        }
        public Column GetById(string Id){
            
            Column columnFound = _columnCollection.Find(x => x.Id == Id).FirstOrDefault();
            return columnFound;
        }
        public void Update(Column columnUpdated){

            var filter = Builders<Column>.Filter.Eq(x => x.Id, columnUpdated.Id);
            var update = Builders<Column>.Update
                .Set(x => x.WorkspaceId, columnUpdated.WorkspaceId)
                .Set(x => x.Title, columnUpdated.Title)
                .Set(x => x.Index, columnUpdated.Index);


            _columnCollection.UpdateOne(filter, update);    
        }

        public void Delete(string Id){
            var filter = Builders<Column>.Filter.Eq(x => x.Id, Id);
            _columnCollection.DeleteOneAsync(filter);    
        }
    }
}