using MongoDB.Driver;
using Synthesis.Model;
using Synthesis.Connection;
using Synthesis.Domain.DTOs;
using MongoDB.Bson;

namespace  Synthesis.Repository
{
    public class WorkspaceRepository : IWorkspaceRepository {
        private readonly IMongoCollection<Workspace> _workspaceCollection;
        public WorkspaceRepository(){
            IMongoDatabase database = ConnectionContext.ConnectionToMongo();
            _workspaceCollection = database.GetCollection<Workspace>("workspaces");

        }
        public void Add(Workspace workspace){
            _workspaceCollection.InsertOne(workspace);  
        }
        public List<WorkspaceDTO> Get() {
            FilterDefinition<Workspace> filter = Builders<Workspace>.Filter.Empty;
            var projection = Builders<Workspace>.Projection.Include("id").Include("name");
            List<WorkspaceDTO> result = _workspaceCollection.Find(filter).Project<WorkspaceDTO>(projection).ToList();
            return result;
        }
        public Workspace Get(string workspaceId){
            Workspace workspaceFound = _workspaceCollection.Find(x => x.Id == workspaceId).FirstOrDefault();
            if(workspaceFound == null){
                throw new ArgumentException("Workspace não encontrado.");
            }
            return workspaceFound;
        }
    }
}