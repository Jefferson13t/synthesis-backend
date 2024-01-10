using MongoDB.Driver;
using Synthesis.Model;
using Synthesis.Connection;
using Synthesis.Domain.DTOs;
using MongoDB.Bson;

namespace  Synthesis.Repository
{
    public class UserRepository : IUserRepository {
        private readonly IMongoCollection<User> _userCollection;
        public UserRepository(){
            IMongoDatabase database = ConnectionContext.ConnectionToMongo();
            _userCollection = database.GetCollection<User>("users");
        }
        public void Add(User user){
            _userCollection.InsertOne(user);
        }
        public List<UserDTO> Get() {
            FilterDefinition<User> filter = Builders<User>.Filter.Empty;
            var projection = Builders<User>.Projection.Include("id").Include("name").Include("photo");
            List<UserDTO> result = _userCollection.Find(filter).Project<UserDTO>(projection).ToList();
            return result;
        }
    }
}