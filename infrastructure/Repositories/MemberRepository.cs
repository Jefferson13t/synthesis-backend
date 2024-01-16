using MongoDB.Driver;
using Synthesis.Model;
using Synthesis.Connection;
using Synthesis.Domain.DTOs;
using MongoDB.Bson;

namespace  Synthesis.Repository
{
    public class MemberRepository : IMemberRepository {
        private readonly IMongoCollection<Member> _memberCollection;
        public MemberRepository(){
            IMongoDatabase database = ConnectionContext.ConnectionToMongo();
            _memberCollection = database.GetCollection<Member>("members");

        }
        public void Add(Member member){
            _memberCollection.InsertOne(member);  
        }
        public List<MemberDTO> Get() {
            FilterDefinition<Member> filter = Builders<Member>.Filter.Empty;
            var projection = Builders<Member>.Projection.Include("id").Include("userId").Include("workspaceId").Include("role");
            List<MemberDTO> result = _memberCollection.Find(filter).Project<MemberDTO>(projection).ToList();
            return result;
        }
    }
}