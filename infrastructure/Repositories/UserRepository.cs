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
            var projection = Builders<User>.Projection.Include("id").Include("name").Include("email");
            List<UserDTO> result = _userCollection.Find(filter).Project<UserDTO>(projection).ToList();
            return result;
        }
        public User GetByEmail(string Email){
            
            User userFound = _userCollection.Find(x => x.Email == Email).FirstOrDefault();
            return userFound;
        }
        public User GetById(string Id){
            
            User userFound = _userCollection.Find(x => x.Id == Id).FirstOrDefault();
            return userFound;
        }

        public void Update(User userUpdated){

            var filter = Builders<User>.Filter.Eq(x => x.Id, userUpdated.Id);
            var update = Builders<User>.Update
                .Set(x => x.Name, userUpdated.Name)
                .Set(x => x.Email, userUpdated.Email)
                .Set(x => x.Password, userUpdated.Password);

            _userCollection.UpdateOne(filter, update);    
        }

        public void Delete(string Id){
            var filter = Builders<User>.Filter.Eq(x => x.Id, Id);
            _userCollection.DeleteOneAsync(filter);    
        }
    }
}