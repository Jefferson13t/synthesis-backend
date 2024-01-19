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
    }
}